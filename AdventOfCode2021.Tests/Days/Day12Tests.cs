namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day12;

    [TestClass]
    public class Day12Tests
    {
        public static string[][] SmallExampleInput = new[]
        {
            new[] { "start", "A" },
            new[] { "start", "b" },
            new[] { "A", "c" },
            new[] { "A", "b" },
            new[] { "b", "d" },
            new[] { "A", "end" },
            new[] { "b", "end" },
        };

        public static string[][] SlightlyLargerExampleInput = new[]
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

        public static string[][] LargerExampleInput = new[]
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

        [TestMethod]
        public void CountPaths_ForSmallExample_Returns10()
        {
            var input = SmallExampleInput;

            var result = Part1.CountPaths(input);

            Assert.AreEqual<ulong>(10, result);
        }

        [TestMethod]
        public void CountPaths_ForSlightlyLargerExample_Returns19()
        {
            var input = SlightlyLargerExampleInput;

            var result = Part1.CountPaths(input);

            Assert.AreEqual<ulong>(19, result);
        }

        [TestMethod]
        public void CountPaths_ForLargerExample_Returns226()
        {
            var input = LargerExampleInput;

            var result = Part1.CountPaths(input);

            Assert.AreEqual<ulong>(226, result);
        }
    }
}
