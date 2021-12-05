namespace AdventOfCode2021.Days.Day04
{

    public readonly record struct Game(int[] Numbers, int[,,] Boards, Dictionary<int, List<BoardMapping>> Mapping)
    {
        public const int BoardWidth = 5;

        public const int BoardHeight = 5;

        public int CalculateScore(BoardMapping mapping, HashSet<int> drawn)
        {
            var boards = this.Boards;

            return Enumerable.Range(0, BoardHeight)
                .SelectMany(row => Enumerable.Range(0, BoardWidth).Select(column => boards[mapping.BoardId, row, column]))
                .Where(number => !drawn.Contains(number))
                .Sum() * mapping.Value;
        }

        public bool IsFinishingMove(HashSet<int> drawn, BoardMapping mapping)
        {
            for (var row = 0; row < Game.BoardHeight; ++row)
            {
                if (!drawn.Contains(this.Boards[mapping.BoardId, row, mapping.Column])) break;
                else if (row == Game.BoardHeight - 1) return true;
            }

            for (var column = 0; column < Game.BoardWidth; ++column)
            {
                if (!drawn.Contains(this.Boards[mapping.BoardId, mapping.Row, column])) break;
                else if (column == Game.BoardWidth - 1) return true;
            }

            return false;
        }

        public static Game Parse(string[] input)
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

            return new Game(numbers, boards, boardMap);
        }
    }

    public readonly record struct BoardMapping(int Value, int BoardId, int Row, int Column);
}
