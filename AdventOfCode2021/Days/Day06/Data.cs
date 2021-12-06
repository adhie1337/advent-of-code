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
}
