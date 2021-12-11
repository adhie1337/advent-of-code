namespace AdventOfCode2021.Days.Day08
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => SumOutputValues(input.Select(Line.Parse));

        public static int SumOutputValues(IEnumerable<Line> lines) => lines.Sum(_ => _.OutputValue);
    }
}
