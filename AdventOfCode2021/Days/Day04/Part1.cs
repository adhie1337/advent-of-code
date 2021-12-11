namespace AdventOfCode2021.Days.Day04
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CalclateScoreOfWinner(Game.Parse(input));

        public static int CalclateScoreOfWinner(Game game)
        {
            var drawn = new HashSet<int>();

            for (var i = 0; i < game.Numbers.Length; ++i)
            {
                var number = game.Numbers[i];
                drawn.Add(number);

                if (game.Mapping.TryGetValue(number, out var mappings))
                {
                    var finishingMove = mappings.Where(_ => game.IsFinishingMove(drawn, _))
                        .Cast<BoardMapping?>()
                        .FirstOrDefault();

                    if (finishingMove is BoardMapping mapping) return game.CalculateScore(mapping, drawn);
                }
            }

            return 0;
        }
    }
}
