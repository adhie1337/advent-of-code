namespace AdventOfCode2021.Days
{
    using static Direction;

    public enum Direction { Forward, Up, Down }

    public readonly record struct Command(Direction Direction, byte Delta)
    {
        public static Command Parse(string command) => Parse(command.Split(' '));

        public static Command Parse(string[] commandParts)
            =>  new Command(commandParts[0].ToDirection(), byte.Parse(commandParts[1]));
    }

    public readonly record struct Position(uint HorizontalPosition, uint Depth)
    {
        public static readonly Position Empty = new Position();

        public uint ToInt() => this.HorizontalPosition * this.Depth;
    }

    public class Day02Part1 : Solution<uint>
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

    public static class Extensions
    {
        public static Direction ToDirection(this string value) => Enum.Parse<Direction>(value.Capitalize());

        public static string Capitalize(this string value) => char.ToUpper(value[0]) + value[1..];
    }
}
