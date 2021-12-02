namespace AdventOfCode2021.Days
{
    using static Direction;

    public readonly record struct State(uint HorizontalPosition, int Depth, int Aim)
    {
        public static readonly State Start = new State(0, 0, 0);

        public long ToInt() => this.HorizontalPosition * this.Depth;
    }

    public class Day02Part2 : Solution<long>
    {
        public override long Apply(string[] input)
        {
            var commands = input.Select(Command.Parse);
            var result = commands.Aggregate(State.Start, Execute);

            return result.ToInt();
        }

        public State Execute(State s, Command command) => command switch
        {
            Command(Up, var delta) => s with { Aim = s.Aim - delta },
            Command(Down, var delta) => s with { Aim = s.Aim + delta },
            Command(Forward, var delta) => new State(s.HorizontalPosition + delta, s.Depth + s.Aim * delta, s.Aim),
            _ => throw new NotSupportedException($"The direction { command.Direction } is not supported!"),
        };
    }
}
