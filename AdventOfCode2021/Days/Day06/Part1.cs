namespace AdventOfCode2021.Days.Day06
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CalculateSchoolSize(input.SelectMany(LanternFish.Parse));

        public static int CalculateSchoolSize(IEnumerable<LanternFish> startState)
            => Enumerable.Range(0, 80).Aggregate(startState, (a, _) => a.SelectMany(_ => _.NextDay).ToArray()).Count();
    }
}
