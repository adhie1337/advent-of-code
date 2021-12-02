namespace AdventOfCode2021.Days
{
    using System.Diagnostics;
    using static Direction;

    public enum Direction { Forward, Up, Down }

    public readonly record struct Command(Direction Direction, byte Distance)
    {
        public Position ExecuteAt(Position position) => this.Direction switch
        {
            Forward => position.MoveForward(this.Distance),
            Up => position.MoveUp(this.Distance),
            Down => position.MoveDown(this.Distance),
            _ => throw new NotSupportedException($"The direction { this.Direction } is not supported!"),
        };
    }

    public readonly record struct Position(uint HorizontalPosition, uint Depth)
    {
        public Position MoveForward(byte distance) => new Position(this.HorizontalPosition + distance, this.Depth);

        public Position MoveUp(byte distance) => new Position(this.HorizontalPosition, this.Depth - distance);

        public Position MoveDown(byte distance) => new Position(this.HorizontalPosition, this.Depth + distance);
    }

    public static class Day02Part1
    {
        public static async Task<string?> Execute()
        {
            const string DataFilePath = "data/day02/input";
            var file = new FileInfo(DataFilePath);

            if (!file.Exists)
            {
                return $"File not exists, please download input file to {DataFilePath}...";
            }
            else
            {
                Debug.WriteLine($"Found file at {DataFilePath} with { file.Length } bytes!");
            }

            var data = await File.ReadAllLinesAsync(DataFilePath);
            var commands = data.Select(Parse);
            var result = commands.Aggregate(new Position(0, 0), ExecuteCommand);

            Console.WriteLine(result.HorizontalPosition * result.Depth);

            return default;
        }

        public static Command Parse(string command)
            =>  new Command(Enum.Parse<Direction>(Capitalize(command.Split(' ')[0])), byte.Parse(command.Split(' ', 2)[1]));

        public static Position ExecuteCommand(Position position, Command command) => command.ExecuteAt(position);

        public static string Capitalize(string value) => char.ToUpper(value[0]) + value[1..];
    }
}
