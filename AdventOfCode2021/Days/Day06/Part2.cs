namespace AdventOfCode2021.Days.Day06
{
    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input)
        {
            var school = LanternFishSchool.Parse(input);

            for (var i = 0; i < 256; ++i)
            {
                school = school.NextDay();
            }

            static ulong Add(ulong left, ulong right) => left + right;

            return school.FishCounts.Aggregate(default(ulong), Add);
        }
    }
}
