namespace AdventOfCode2021.Days.Day07
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CalculateBestPosition(input.SelectMany(_ => _.Split(',')).Select(int.Parse).ToArray());

        public static int CalculateBestPosition(int[] positions)
        {
            var min = positions.Min();
            var max = positions.Max();

            var best = min;
            var bestScore = default(int?);

            for (var act = min; act <= max; ++act)
            {
                var actScore = positions.Select(_ => Math.Abs(_ - act)).Sum();

                if (!bestScore.HasValue || bestScore.Value > actScore)
                {
                    best = act;
                    bestScore = actScore;
                }
            }

            return bestScore!.Value;
        }
    }
}
