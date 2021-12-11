namespace AdventOfCode2021.Days.Day10
{
    public class Part2 : Solution<ulong>
    {
        private static readonly Dictionary<char, ulong> Scores = new Dictionary<char, ulong>()
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 },
        };

        private static readonly Dictionary<char, char> CloseMap = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' },
        };

        public override ulong Apply(string[] input) => CalculateAutocompleteScore(input);

        public static ulong CalculateAutocompleteScore(IEnumerable<string> lines)
            => GetMiddleScore(lines.Select(CalculateAutocompleteScore));

        public static ulong? CalculateAutocompleteScore(string line)
        {
            var stack = new Stack<char>();

            for (var i = 0; i < line.Length; ++i)
            {
                if (CloseMap.TryGetValue(line[i], out var closingChar)) stack.Push(closingChar);
                else if (stack.Peek() == line[i]) stack.Pop();
                else return default;
            }

            return stack.Aggregate((ulong)0, (a, c) => a * 5 + Scores[c]);
        }

        public static ulong GetMiddleScore(IEnumerable<ulong?> scores)
        {
            var scoresArray = scores.Where(_ => _.GetValueOrDefault() != 0)
                .OrderBy(_ => _!.Value)
                .ToArray();

            return scoresArray[scoresArray.Length / 2]!.Value;
        }
    }
}
