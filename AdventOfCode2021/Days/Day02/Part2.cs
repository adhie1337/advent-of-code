namespace AdventOfCode2021.Days.Day02
{
    using static Direction;

    public class Part2 : Solution<long>
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
