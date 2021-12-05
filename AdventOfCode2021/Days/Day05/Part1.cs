namespace AdventOfCode2021.Days.Day05
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var data = input.Select(Line.Parse).ToArray();
            var points = data.SelectMany(Generate).ToArray();

            return points.GroupBy(_ => _)
                .Count(_ => _.Count() > 1);
        }

        public IEnumerable<Point> Generate(Line line)
        {
            if (line.IsHorizontal)
            {
                for (var i = line.LeftX; i <= line.RightX; ++i)
                    yield return new Point(i, line.Start.Y);
            }
            else if (line.IsVertical)
            {
                for (var j = line.TopY; j <= line.BottomY; ++j)
                    yield return new Point(line.Start.X, j);
            }
        }
    }
}