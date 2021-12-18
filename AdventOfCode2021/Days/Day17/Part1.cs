namespace AdventOfCode2021.Days.Day17
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => GetHighestY(TargetArea.Parse(input[0]));

        public static int GetHighestY(TargetArea target)
            => target.GetPossibleAims().SelectMany(v => target.Simulate(Point.Origin, v)).Max(p => p.Y);
    }
}
