namespace AdventOfCode2021.Days.Day09
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var lowPoints = HeightMap.Parse(input)
                .GetLowPoints()
                .ToArray();
            return lowPoints.Sum(_ => _.RiskLevel);
        }
    }
}
