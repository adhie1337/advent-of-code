namespace AdventOfCode2021.Days.Day22
{
    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => CountOnCubes(input.Select(Command.Parse));

        public static ulong CountOnCubes(IEnumerable<Command> commands)
            => Command.SplitCommands(commands).Aggregate(0ul, (a, s) => a + s.Count);
    }
}
