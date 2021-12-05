namespace AdventOfCode2021.Days.Day04
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var game = Game.Parse(input);
            var drawn = new HashSet<int>();
            var boardCount = game.Boards.GetLength(0);
            var winnerBoards = new List<int>(boardCount);

            for (var i = 0; i < game.Numbers.Length; ++i)
            {
                var number = game.Numbers[i];
                drawn.Add(number);

                if (game.Mapping.TryGetValue(number, out var mappings))
                {
                    var finishingMoves = mappings.Where(_ => !winnerBoards.Contains(_.BoardId) && game.IsFinishingMove(drawn, _));

                    foreach (var mapping in finishingMoves)
                    {
                        winnerBoards.Add(mapping.BoardId);

                        if (winnerBoards.Count == boardCount) return game.CalculateScore(mapping, drawn);
                    }
                }
            }

            return 0;
        }
    }
}
