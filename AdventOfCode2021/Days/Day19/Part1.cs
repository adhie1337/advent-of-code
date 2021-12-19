namespace AdventOfCode2021.Days.Day19
{
    using static Scanners;

    public class Part1 : Solution<long>
    {
        public override long Apply(string[] input) => CountBeacons(Parse(input), 12);

        public static long CountBeacons(Scanner[] scanners, int limit)
            => TranslateToZero(scanners, limit).SelectMany(s => s.VisibleBeacons).Distinct().LongCount();
    }
}
