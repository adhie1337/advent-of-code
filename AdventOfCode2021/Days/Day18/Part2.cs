namespace AdventOfCode2021.Days.Day18
{
    using static Number;

    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => GetMaxMagnitudeOfPairsAdded(input.Select(Parse).ToArray());

        public static ulong GetMaxMagnitudeOfPairsAdded(INumber[] numbers)
            => (from left in numbers
                from right in numbers
                where left != right
                select Add(left, right).Magnitude).Max();
    }
}
