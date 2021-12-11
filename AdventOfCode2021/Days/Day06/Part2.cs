namespace AdventOfCode2021.Days.Day06
{
    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => CalculateFishSchoolSize(LanternFishSchool.Parse(input));

        public static ulong CalculateFishSchoolSize(LanternFishSchool school)
            => Enumerable.Range(0, 256).Aggregate(school, (s, _) => s.NextDay()).FishCounts.Aggregate(default(ulong), Add);

        public static ulong Add(ulong left, ulong right) => left + right;
    }
}
