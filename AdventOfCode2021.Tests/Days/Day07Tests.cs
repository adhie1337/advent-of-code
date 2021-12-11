namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day07;

    [TestClass]
    public class Day07Tests
    {
        private static readonly int[] Example = new[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        [TestMethod]
        public void CalculateBestPosition_ForExample_Returns37()
        {
            var input = Example;

            var result = Part1.CalculateBestPosition(input);

            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void CalculateBestPosition_ForExample_Returns168()
        {
            var input = Example;

            var result = Part2.CalculateBestPosition(input);

            Assert.AreEqual(168, result);
        }
    }
}
