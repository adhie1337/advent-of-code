namespace AdventOfCode2021.Tests.Days.Day09
{
    using AdventOfCode2021.Days.Day09;

    public static class Example
    {
        public static readonly HeightMap HeightMap = new HeightMap()
        {
            Heights = new byte[,]
            {
                { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
                { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
                { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
                { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
                { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
            }
        };
    }
}
