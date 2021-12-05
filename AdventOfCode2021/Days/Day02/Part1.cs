namespace AdventOfCode2021.Days.Day02
{
    using static Direction;

    public class Part1 : Solution<uint>
    {
        public override uint Apply(string[] input)
        {
            var commands = input.Select(Command.Parse);
            var result = commands.Aggregate(Position.Empty, Execute);

            return result.ToInt();
        }

        public Position Execute(Position p, Command command) => command switch
        {
            Command(Forward, var delta) => new Position(p.HorizontalPosition + delta, p.Depth),
            Command(Up, var delta) => new Position(p.HorizontalPosition, p.Depth - delta),
            Command(Down, var delta) => new Position(p.HorizontalPosition, p.Depth + delta),
            Command(var direction, _) => throw new NotSupportedException($"The direction { direction } is not supported!"),
        };
    }
}
