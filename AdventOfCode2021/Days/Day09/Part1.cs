namespace AdventOfCode2021.Days.Day09
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => GetLowRiskSum(HeightMap.Parse(input));

        public static int GetLowRiskSum(HeightMap heightMap) => heightMap.GetLowPoints().Sum(_ => _.RiskLevel);
    }
}
