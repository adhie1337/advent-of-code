namespace AdventOfCode2021.Days.Day04
{
    public class Part1 : Solution<int>
    {
        public const int BoardWidth = 5;
        public const int BoardHeight = 5;

        public override int Apply(string[] input)
        {
            var game = GetBingoGame(input);
            var drawn = new HashSet<int>();

            for (var i = 0; i < game.Numbers.Length; ++i)
            {
                var number = game.Numbers[i];
                drawn.Add(number);

                if (game.Mapping.TryGetValue(number, out var mappings))
                {
                    foreach (var mapping in mappings)
                    {
                        for (var row = 0; row < BoardHeight; ++row)
                        {
                            if (!drawn.Contains(game.Boards[mapping.BoardId, row, mapping.Column])) break;
                            else if (row == BoardHeight - 1) return CalculateScore(game, mapping, drawn);
                        }

                        for (var column = 0; column < BoardWidth; ++column)
                        {
                            if (!drawn.Contains(game.Boards[mapping.BoardId, mapping.Row, column])) break;
                            else if (column == BoardWidth - 1) return CalculateScore(game, mapping, drawn);
                        }
                    }
                }
            }

            return 0;
        }

        public static int CalculateScore(BingoGame game, BoardMapping mapping, HashSet<int> drawn)
            => Enumerable.Range(0, BoardHeight)
                .SelectMany(row => Enumerable.Range(0, BoardWidth).Select(column => game.Boards[mapping.BoardId, row, column]))
                .Where(number => !drawn.Contains(number))
                .Sum() * mapping.Value;

        public static BingoGame GetBingoGame(string[] input)
        {
            var numbers = input[0].Split(",").Select(int.Parse).ToArray();
            var boardCount = (input.Length - 1) / 6;
            var boards = new int[boardCount, BoardWidth, BoardHeight];
            var boardMap = new Dictionary<int, List<BoardMapping>>();

            for (var i = 0; i < boardCount; ++i)
            {
                var boardStart = 2 + i * (BoardHeight + 1);

                for (var row = 0; row < BoardHeight; ++row)
                {
                    var line = input[boardStart + row].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (var column = 0; column < BoardWidth; ++column)
                    {
                        var number = int.Parse(line[column]);
                        boards[i, row, column] = number;
                        var entry = new BoardMapping(number, i, row, column);

                        if (boardMap.TryGetValue(number, out var l)) l.Add(entry);
                        else boardMap[number] = new List<BoardMapping>() { entry };
                    }
                }
            }

            return new BingoGame(numbers, boards, boardMap);
        }
    }
}
