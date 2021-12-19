namespace AdventOfCode2021.Days.Day19
{
    using static Scanners;

    public class Part2 : Solution<long>
    {
        public override long Apply(string[] input) => GetMaxDistance(Parse(input), 12);

        public static long GetMaxDistance(Scanner[] scanners, int limit)
        {
            var translated = TranslateToZero(scanners, limit);

            return translated
                .SelectMany(a => translated.Select(b => a.Position!.Value.ManhattanDistance(b.Position!.Value)))
                .Max();
        }
    }
}
