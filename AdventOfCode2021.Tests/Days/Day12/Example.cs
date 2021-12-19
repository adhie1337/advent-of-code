namespace AdventOfCode2021.Tests.Days.Day12
{
    public static class Example
    {
        public static readonly string[][] SmallInput = new[]
        {
            new[] { "start", "A" },
            new[] { "start", "b" },
            new[] { "A", "c" },
            new[] { "A", "b" },
            new[] { "b", "d" },
            new[] { "A", "end" },
            new[] { "b", "end" },
        };

        public static readonly string[][] SlightlyLargerInput = new[]
        {
            new[] { "dc", "end" },
            new[] { "HN", "start" },
            new[] { "start", "kj" },
            new[] { "dc", "start" },
            new[] { "dc", "HN" },
            new[] { "LN", "dc" },
            new[] { "HN", "end" },
            new[] { "kj", "sa" },
            new[] { "kj", "HN" },
            new[] { "kj", "dc" },
        };

        public static readonly string[][] LargerInput = new[]
        {
            new[] { "fs", "end" },
            new[] { "he", "DX" },
            new[] { "fs", "he" },
            new[] { "start", "DX" },
            new[] { "pj", "DX" },
            new[] { "end", "zg" },
            new[] { "zg", "sl" },
            new[] { "zg", "pj" },
            new[] { "pj", "he" },
            new[] { "RW", "he" },
            new[] { "fs", "DX" },
            new[] { "pj", "RW" },
            new[] { "zg", "RW" },
            new[] { "start", "pj" },
            new[] { "he", "WI" },
            new[] { "zg", "he" },
            new[] { "pj", "fs" },
            new[] { "start", "RW" },
        };
    }
}
