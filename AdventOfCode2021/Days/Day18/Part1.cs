namespace AdventOfCode2021.Days.Day18
{
    public class Part1 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => GetSumMagnitude(input.Select(Number.Parse).ToArray());

        public static ulong GetSumMagnitude(INumber[] numbers) => numbers.Aggregate(Number.Add).Magnitude;
    }
}
