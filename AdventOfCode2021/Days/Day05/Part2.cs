namespace AdventOfCode2021.Days.Day05
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => CountOverlappingPoints(input.Select(Line.Parse));

        public static int CountOverlappingPoints(IEnumerable<Line> lines)
            => lines.SelectMany(_ => _.Points)
                .ToArray()
                .GroupBy(_ => _)
                .Count(_ => _.Count() > 1);
    }
}
