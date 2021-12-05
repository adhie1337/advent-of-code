namespace AdventOfCode2021.Days
{
    public class Day04Part2 : Solution<int>
    {
        public const int BoardWidth = Day04Part1.BoardWidth;
        public const int BoardHeight = Day04Part1.BoardHeight;

        public override int Apply(string[] input)
        {
            var game = Day04Part1.GetBingoGame(input);
            var drawn = new HashSet<int>();
            var boardCount = game.Boards.GetLength(0);
            var winnerBoards = new List<int>(boardCount);

            for (var i = 0; i < game.Numbers.Length; ++i)
            {
                var number = game.Numbers[i];
                drawn.Add(number);

                if (game.Mapping.TryGetValue(number, out var mappings))
                {
                    foreach (var mapping in mappings.Where(m => !winnerBoards.Contains(m.BoardId)))
                    {
                        for (var row = 0; row < BoardHeight; ++row)
                        {
                            if (!drawn.Contains(game.Boards[mapping.BoardId, row, mapping.Column]))
                            {
                                break;
                            }
                            else if (row == BoardHeight - 1)
                            {
                                winnerBoards.Add(mapping.BoardId);

                                if (winnerBoards.Count == boardCount) return Day04Part1.CalculateScore(game, mapping, drawn);
                            }
                        }

                        if (winnerBoards.Contains(mapping.BoardId)) continue;

                        for (var column = 0; column < BoardWidth; ++column)
                        {
                            if (!drawn.Contains(game.Boards[mapping.BoardId, mapping.Row, column])) break;
                            else if (column == BoardWidth - 1)
                            {
                                winnerBoards.Add(mapping.BoardId);

                                if (winnerBoards.Count == boardCount) return Day04Part1.CalculateScore(game, mapping, drawn);
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}
