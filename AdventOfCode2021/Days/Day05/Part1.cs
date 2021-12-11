namespace AdventOfCode2021.Days.Day05
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CountOverlapPointsWithoutDiagonals(input.Select(Line.Parse));

        public static int CountOverlapPointsWithoutDiagonals(IEnumerable<Line> lines)
            => lines
                .Where(_ => _.IsHorizontal || _.IsVertical)
                .SelectMany(_ => _.Points)
                .ToArray()
                .GroupBy(_ => _)
                .Count(_ => _.Count() > 1);
    }
}
