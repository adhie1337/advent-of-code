namespace AdventOfCode2021.Days.Day17
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => GetSuccesfulAimCount(TargetArea.Parse(input[0]));

        public static int GetSuccesfulAimCount(TargetArea target) => target.GetPossibleAims().Count;
    }
}
