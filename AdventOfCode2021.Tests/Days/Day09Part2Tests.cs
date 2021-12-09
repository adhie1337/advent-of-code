namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day09;

    [TestClass]
    public class Day09Part2Tests
    {
        [TestMethod]
        public void Apply_ForExample_Returns1134()
        {
            var input = new[] { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" };

            var result = new Part2().Apply(input);

            Assert.AreEqual(1134, result);
        }
    }
}
