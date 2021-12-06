namespace AdventOfCode2021.Days.Day06
{
    public readonly record struct LanternFish(int State)
    {
        public IEnumerable<LanternFish> NextDay
        {
            get
            {
                if (this.State > 0) yield return new LanternFish(this.State - 1);
                else
                {
                    yield return new LanternFish(6);
                    yield return new LanternFish(8);
                }
            }
        }

        public static IEnumerable<LanternFish> Parse(string input) => Parse(input.Split(","));

        public static IEnumerable<LanternFish> Parse(string[] values) => values.Select(int.Parse).Select(_ => new LanternFish(_));
    }

    public readonly record struct LanternFishSchool(ulong[] FishCounts)
    {
        public LanternFishSchool NextDay()
        {
            var nextDay = this.FishCounts.Skip(1).Concat(new[] { (ulong)0 }).ToArray();

            nextDay[6] += this.FishCounts[0];
            nextDay[8] += this.FishCounts[0];

            return new LanternFishSchool(nextDay);
        }

        public static LanternFishSchool Parse(string[] input)
        {
            var groups = input.SelectMany(_ => _.Split(","))
                .GroupBy(int.Parse)
                .ToDictionary(_ => _.Key, _ => (ulong)_.Count());

            var fishCounts = Enumerable.Range(0, 9)
                .Select(_ => groups.TryGetValue(_, out var r) ? r : 0)
                .ToArray();

            return new LanternFishSchool(fishCounts);
        }
    }
}
