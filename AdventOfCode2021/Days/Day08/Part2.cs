namespace AdventOfCode2021.Days.Day08
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => input.Select(Line.Parse).Sum(_ => _.OutputValue);
    }
}
