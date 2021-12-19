namespace AdventOfCode2021.Days.Day19
{
    using static Scanners;

    public class Part2 : Solution<long>
    {
        public override long Apply(string[] input) => GetMaxDistance(Parse(input), 12);

        public static long GetMaxDistance(Scanner[] scanners, int limit)
        {
            var translated = TranslateToZero(scanners, limit);

            var distances =
                from a in translated
                from b in translated
                select a.Position!.Value.ManhattanDistance(b.Position!.Value);

            return distances.Max();
        }
    }
}
