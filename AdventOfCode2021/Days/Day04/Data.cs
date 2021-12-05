namespace AdventOfCode2021.Days.Day04
{

    public readonly record struct BingoGame(int[] Numbers, int[,,] Boards, Dictionary<int, List<BoardMapping>> Mapping);

    public readonly record struct BoardMapping(int Value, int BoardId, int Row, int Column);
}