namespace AdventOfCode2021.Days.Day14
{
    using System.Collections.Concurrent;

    public class Part2 : Solution<ValueTask<ulong>>
    {
        public override async ValueTask<ulong> Apply(string[] input) => await GetResultAfter40Steps(PolimerizationState.Parse(input));

        public static async ValueTask<ulong> GetResultAfter40Steps(PolimerizationState state)
        {
            var result = await SimulateCharCounts(state, 40);

            return result!.Max() - result!.Min();
        }

        public static async ValueTask<ulong[]> SimulateCharCounts(PolimerizationState state, int simulationLength)
        {
            var (result, rules, queue, charCount) = Init(state, simulationLength);

            var concurrentQueue = new ConcurrentQueue<((byte, byte) Pair, int Step)>(queue.Distinct());

            var tasks = Enumerable.Range(0, Environment.ProcessorCount - 1)
                .Select(i => Task.Run(() => TaskImpl(simulationLength, i, charCount, rules, concurrentQueue)))
                .ToArray();

            var mergedDict = (await Task.WhenAll(tasks))
                .SelectMany(d => d)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var d in queue.Select(p => mergedDict[p.Pair]))
            {
                for (var i = 0; i < charCount; ++i)
                {
                    result[i] += d[i];
                }
            }

            return result;
        }

        public static (ulong[] Result, byte[] Rules, Queue<((byte, byte) Pair, int Step)> Queue, int CharCount) Init(PolimerizationState state, int simulationLength)
        {
            var chars = state.Template.Concat(state.Rules.Values)
                .Distinct()
                .ToArray();
            var charCount = chars.Count();

            var keyMap = chars.OrderBy(c => c)
                .Zip(Enumerable.Range(0, charCount))
                .ToDictionary(p => p.First, p => (byte)p.Second);

            var result = Enumerable.Range(0, charCount).Select(c => (ulong)state.Template.Count(t => keyMap[t] == c)).ToArray();
            var ruleArray = state.Rules
                .Select(p => (Chars: keyMap[p.Key.Item1] + (keyMap[p.Key.Item2] * charCount), Mapped: keyMap[p.Value]))
                .OrderBy(_ => _.Item1)
                .ToArray();

            var rules = new byte[ruleArray.Max(p => p.Chars) + 1];
            foreach (var r in ruleArray) rules[r.Chars] = r.Mapped;

            var initialSteps = state.Template.Select(c => keyMap[c]).Zip(state.Template.Skip(1).Select(c => keyMap[c]))
                .Select(pair => (pair, 1))
                .ToArray();

            var queue = new Queue<((byte, byte) Pair, int Step)>(initialSteps);
            queue.EnsureCapacity((int)(initialSteps.Count() * Math.Pow(2, simulationLength / 2 - 1)));

            while (queue.TryPeek(out var p) && p.Step < simulationLength / 2)
            {
                var act = queue.Dequeue();

                var nextChar = rules[act.Pair.Item1 + (charCount * act.Pair.Item2)];

                result[nextChar]++;

                queue.Enqueue(((act.Pair.Item1, nextChar), act.Step + 1));
                queue.Enqueue(((nextChar, act.Pair.Item2), act.Step + 1));
            }

            return (result, rules, queue, charCount);
        }

        public static Dictionary<(byte, byte), ulong[]> TaskImpl(int simulationLength, int i, int charCount, byte[] rules, ConcurrentQueue<((byte, byte) Pair, int Step)> queue)
        {
            var result = new Dictionary<(byte, byte), ulong[]>();

            var stack = new Stack<((byte, byte) Pair, int Step)>();
            stack.EnsureCapacity(simulationLength / 2 + 2);

            while (queue.TryDequeue(out var step))
            {
                stack.Push(step);

                var innerResult = new ulong[charCount];

                while (stack.TryPop(out var next))
                {
                    if (next.Step <= simulationLength)
                    {
                        var nextChar = rules[next.Pair.Item1 + (charCount * next.Pair.Item2)];

                        innerResult[nextChar]++;

                        stack.Push(((next.Pair.Item1, nextChar), next.Step + 1));
                        stack.Push(((nextChar, next.Pair.Item2), next.Step + 1));
                    }
                }

                result[step.Pair] = innerResult;
            }

            return result;
        }
    }
}
