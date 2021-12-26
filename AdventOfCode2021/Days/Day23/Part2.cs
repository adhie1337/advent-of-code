namespace AdventOfCode2021.Days.Day23
{
    public class Part2 : Solution<ulong>
    {
        public static string[] ExtraLines = new[]
            {
                "  #D#C#B#A#",
                "  #D#B#A#C#",
            };

        public override ulong Apply(string[] input) => GetEnergyNeeded(input);

        public static ulong GetEnergyNeeded(string[] input)
            => Part1.Solve(input[0..3].Concat(ExtraLines).Concat(input[3..]).ToArray())?.G ?? 0ul;
    }
}
