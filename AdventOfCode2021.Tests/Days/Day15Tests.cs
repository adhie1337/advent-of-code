namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day15;

    [TestClass]
    public class Day15Tests
    {
        public static string[] ExampleLines = new string[]
        {
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581",
        };

        [TestMethod]
        public void GetLowRiskPath_ForExample_ReturnsCorrectLength()
        {
            var input = Part1.Parse(ExampleLines);

            var result = Part1.GetLowRiskPath(input);

            Assert.AreEqual(40ul, result);
        }

        [TestMethod]
        public void Part2GetLowRiskPath_ForExample_ReturnsCorrectLength()
        {
            var input = Part2.Parse(ExampleLines);

            var result = Part2.GetLowRiskPath(input);

            Assert.AreEqual(315ul, result);
        }
    }
}
