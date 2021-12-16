namespace AdventOfCode2021.Days.Day15
{
    public class Part1 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => GetLowRiskPath(Parse(input));

        public static byte[,] Parse(string[] input)
        {
            var result = new byte[input.Length, input[0].Length];

            for (var i = 0; i < input.Length; ++i)
            {
                for (var j = 0; j < input[i].Length; ++j)
                {
                    result[i, j] = byte.Parse("" + input[i][j]);
                }
            }

            return result;
        }

        public static ulong GetLowRiskPath(byte[,] map) => Solve(GetStartState(map))?.F ?? ulong.MaxValue;

        public static State GetStartState(byte[,] map)
            => new State()
            {
                GoalX = map.GetLength(1) - 1,
                GoalY = map.GetLength(0) - 1,
                Map = map,
                Steps = new (int, int)[0]
            };

        public static State? Solve(State startState)
        {
            var openSet = new OpenSet(startState.Map.Length) { startState };
            var closedSet = new ClosedSet(startState.Map.Length);

            while (openSet.TryGetNext(out var state))
            {
                if (state.IsGoal) return state;
                else if (!closedSet.Contains(state))
                {
                    closedSet.Add(state);

                    foreach (var neighbor in state.GetNeighbors().OrderBy(n => n.G))
                    {
                        if (!closedSet.Contains(neighbor)) openSet.Add(neighbor);
                    }
                }
            }

            return default;
        }
    }
}
