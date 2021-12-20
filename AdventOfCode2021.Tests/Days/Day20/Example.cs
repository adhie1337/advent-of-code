namespace AdventOfCode2021.Tests.Days.Day20
{
    using System.Collections;
    using System.Linq;

    using AdventOfCode2021.Days.Day20;

    public static class Example
    {
        public static readonly Image Image = new Image()
        {
            Rules = new BitArray("..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#".Select(c => c == '#').ToArray()),
            Pixels = new BitMatrix()
            {
                Width = 5,
                Height = 5,
                Array = new BitArray("#..#.#....##..#..#....###".Select(c => c == '#').ToArray()),
                DefaultValue = false,
            },
        };
    }
}
