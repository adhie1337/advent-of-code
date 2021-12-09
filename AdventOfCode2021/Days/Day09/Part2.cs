namespace AdventOfCode2021.Days.Day09
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var basins = HeightMap.Parse(input)
                .GetBasins()
                .ToArray();

            var result = basins.OrderByDescending(_ => _.Size)
                .Take(3)
                .Aggregate(1, (a, b) => a * b.Size);

            return result;
        }
    }
}
