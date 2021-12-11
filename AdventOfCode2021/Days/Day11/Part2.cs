namespace AdventOfCode2021.Days.Day11
{
    using System.Collections;

    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => GetFirstRoundWhereInSync(input);

        public static int GetFirstRoundWhereInSync(string[] input) => GetFirstRoundWhereInSync(Parse(input));

        public static byte[,] Parse(string[] input)
        {
            var result = new byte[input.Length, input[0].Length];

            for (var i = 0; i < input.Length; ++i)
            {
                var line = input[i];

                for (var j = 0; j < line.Length; ++j)
                {
                    result[i, j] = byte.Parse("" + line[j]);
                }
            }

            return result;
        }

        public static int GetFirstRoundWhereInSync(byte[,] state)
            => Enumerable.Range(1, int.MaxValue).FirstOrDefault(i => SimulateRound(state) == state.Length);

        public static int SimulateRound(byte[,] state)
        {
            var flashCount = 0;
            var flashMap = new BitArray(state.Length);

            for (var i = 0; i < state.GetLength(0); ++i)
                for (var j = 0; j < state.GetLength(1); ++j)
                    state[i, j]++;

            while (true)
            {
                var newFlashes = SimulateNewFlashes(state, flashMap);

                if (newFlashes == 0) break;

                flashCount += newFlashes;
            }

            for (var i = 0; i < state.GetLength(0); ++i)
                for (var j = 0; j < state.GetLength(1); ++j)
                    if (state[i, j] > 9)
                        state[i, j] = 0;

            return flashCount;
        }

        public static int SimulateNewFlashes(byte[,] state, BitArray flashMap)
        {
            var result = 0;

            for (var i = 0; i < state.GetLength(0); ++i)
            {
                for (var j = 0; j < state.GetLength(1); ++j)
                {
                    if (!flashMap[i * state.GetLength(0) + j] && state[i, j] > 9)
                    {
                        flashMap[i * state.GetLength(0) + j] = true;

                        if (i > 0 && j > 0) state[i - 1, j - 1]++;
                        if (i > 0) state[i - 1, j]++;
                        if (i > 0 && j < state.GetLength(1) - 1) state[i - 1, j + 1]++;

                        if (j > 0) state[i, j - 1]++;
                        if (j < state.GetLength(1) - 1) state[i, j + 1]++;

                        if (i < state.GetLength(0) - 1 && j > 0) state[i + 1, j - 1]++;
                        if (i < state.GetLength(0) - 1) state[i + 1, j]++;
                        if (i < state.GetLength(0) - 1 && j < state.GetLength(1) - 1) state[i + 1, j + 1]++;

                        result++;
                    }
                }
            }

            return result;
        }
    }
}
