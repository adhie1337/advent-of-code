namespace AdventOfCode2021.Days.Day23
{
    public class Part1 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => GetEnergyNeeded(input);

        public static ulong GetEnergyNeeded(string[] input) => Solve(input)?.G ?? 0ul;

        public static State? Solve(string[] input) => Solve(State.Parse(input));

        public static State? Solve(State startState)
        {
            var openSet = new OpenSet(1024) { startState };
            var closedSet = new ClosedSet(1024);

            while (openSet.TryGetNext(out var state))
            {
                if (state.IsGoal) return state;
                else if (!closedSet.Contains(state))
                {
                    closedSet.Add(state);

                    foreach (var neighbor in state.GetNeighbors()) openSet.Add(neighbor);
                }
            }

            return default;
        }
    }
}
