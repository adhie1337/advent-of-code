namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day11;

    [TestClass]
    public class Day11Tests
    {
        public static string[] ExampleInput = new[]
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526",
        };

        [TestMethod]
        public void CountFlashes_ForExample_Returns26397()
        {
            var input = ExampleInput;

            var result = Part1.CountFlashes(input);

            Assert.AreEqual<ulong>(1656, result);
        }

        [TestMethod]
        public void CalculateSyntaxErrorScore_ForExample_Returns26397()
        {
            var input = ExampleInput;

            var result = Part2.GetFirstRoundWhereInSync(input);

            Assert.AreEqual(195, result);
        }
    }
}
