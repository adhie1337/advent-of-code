namespace AdventOfCode2021.Days.Day13
{
    using System.Text;

    public class Part2 : Solution<string>
    {
        public override string Apply(string[] input) => PrintResult(Sheet.Parse(input));

        public static string PrintResult(Sheet sheet)
        {
            var lastSheet = Enumerable.Range(0, sheet.Folds.Count()).Aggregate(sheet, (s, _) => s.ApplyFold());
            var maxY = lastSheet.Points.Max(p => p.Y);
            var maxX = lastSheet.Points.Max(p => p.X);
            var resultBuilder = new StringBuilder();

            for (var y = 0; y <= maxY; ++y)
            {
                for (var x = 0; x <= maxX; ++x)
                {
                    resultBuilder.Append(lastSheet.Points.Contains(new Point(x, y)) ? '#' : ' ');
                }

                resultBuilder.AppendLine();
            }

            return resultBuilder.ToString();
        }
    }
}
