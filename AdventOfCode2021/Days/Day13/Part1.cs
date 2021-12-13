namespace AdventOfCode2021.Days.Day13
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CountPointsAfterFirst(Sheet.Parse(input));

        public static int CountPointsAfterFirst(Sheet sheet) => sheet.ApplyFold().Points.Count();
    }
}
