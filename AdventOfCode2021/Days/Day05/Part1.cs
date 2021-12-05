namespace AdventOfCode2021.Days.Day05
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var data = input.Select(Line.Parse).ToArray();
            var points = data
                .Where(_ => _.IsHorizontal || _.IsVertical)
                .SelectMany(_ => _.Points)
                .ToArray();

            return points.GroupBy(_ => _)
                .Count(_ => _.Count() > 1);
        }
    }
}
