namespace AdventOfCode2021.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day09;

    [TestClass]
    public class Day09Part1Tests
    {
        [TestMethod]
        public void GetLowPoints_ForExample_Returns4LowPoints()
        {
            var input = new[] { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" };

            var result = HeightMap.Parse(input).GetLowPoints().ToArray();

            Assert.AreEqual(4, result.Length);
        }
    }
}
