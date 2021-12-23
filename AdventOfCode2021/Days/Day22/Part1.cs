namespace AdventOfCode2021.Days.Day22
{
    public class Part1 : Solution<ulong>
    {
        public static Range3D Range = new Range3D(new Range(-50, 50), new Range(-50, 50), new Range(-50, 50));

        public override ulong Apply(string[] input) => CountOnCubes(input.Select(Command.Parse));

        public static ulong CountOnCubes(IEnumerable<Command> commands)
            => Command.SplitCommands(Filter(commands)).Aggregate(0ul, (a, s) => a + s.Count);

        public static IEnumerable<Command> Filter(IEnumerable<Command> commands)
            => commands.Where(c => c.Range.OverlapsWith(Range))
                .Select(c => new Command(c.State, c.Range.SplitOut(Range).CommonPart));
    }
}
