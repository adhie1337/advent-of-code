namespace AdventOfCode2021.Days.Day02
{
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

    public readonly record struct State(uint HorizontalPosition, int Depth, int Aim)
    {
        public static readonly State Start = new State(0, 0, 0);

        public long ToInt() => this.HorizontalPosition * this.Depth;
    }

    public static class Extensions
    {
        public static Direction ToDirection(this string value) => Enum.Parse<Direction>(value.Capitalize());

        public static string Capitalize(this string value) => char.ToUpper(value[0]) + value[1..];
    }
}