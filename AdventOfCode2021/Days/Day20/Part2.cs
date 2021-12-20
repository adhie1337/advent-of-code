namespace AdventOfCode2021.Days.Day20
{
    using static Image;

    public class Part2 : Part1
    {
        public override long Apply(string[] input) => CountPixelsAfter(Parse(input), 50);
    }
}
