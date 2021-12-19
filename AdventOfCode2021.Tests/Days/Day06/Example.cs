namespace AdventOfCode2021.Tests.Days.Day06
{
    using AdventOfCode2021.Days.Day06;

    public static class Example
    {
        public static readonly LanternFish[] LanternFishes = new[]
        {
            new LanternFish(3),
            new LanternFish(4),
            new LanternFish(3),
            new LanternFish(1),
            new LanternFish(2),
        };

        public static readonly LanternFishSchool School = new LanternFishSchool(new ulong[] { 0, 1, 1, 2, 1, 0, 0, 0, 0, 0 });
    }
}
