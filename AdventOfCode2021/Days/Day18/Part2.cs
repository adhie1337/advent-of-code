namespace AdventOfCode2021.Days.Day18
{
    using static Number;

    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => GetMaxMagnitudeOfPairsAdded(input.Select(Parse).ToArray());

        public static ulong GetMaxMagnitudeOfPairsAdded(INumber[] numbers)
            => numbers.SelectMany(a => numbers.Where(b => a != b).Select(b => Add(a, b).Magnitude)).Max();
    }
}
