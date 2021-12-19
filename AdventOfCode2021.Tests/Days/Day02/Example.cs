namespace AdventOfCode2021.Tests.Days.Day02
{
    using AdventOfCode2021.Days.Day02;
    using static AdventOfCode2021.Days.Day02.Direction;

    public static class Example
    {
        public static readonly Command[] Commands = new[]
        {
            new Command(Forward, 5),
            new Command(Down, 5),
            new Command(Forward, 8),
            new Command(Up, 3),
            new Command(Down, 8),
            new Command(Forward, 2)
        };
    }
}
