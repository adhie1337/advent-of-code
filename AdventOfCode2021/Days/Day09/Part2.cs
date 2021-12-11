namespace AdventOfCode2021.Days.Day09
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => GetBasinSizes(HeightMap.Parse(input));

        public static int GetBasinSizes(HeightMap heightMap)
            => heightMap.GetBasins().ToArray().OrderByDescending(_ => _.Size).Take(3).Aggregate(1, (a, b) => a * b.Size);
    }
}
