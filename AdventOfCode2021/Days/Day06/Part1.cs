namespace AdventOfCode2021.Days.Day06
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var school = input.SelectMany(LanternFish.Parse).ToArray();

            for (var i = 0; i < 80; ++i)
            {
                school = school.SelectMany(_ => _.NextDay).ToArray();
            }

            return school.Count();
        }
    }
}
