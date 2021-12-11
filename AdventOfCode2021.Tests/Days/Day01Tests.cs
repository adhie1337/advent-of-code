namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day01;

    [TestClass]
    public class Day01Tests
    {
        public static readonly int[] ExampleInput = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [TestMethod]
        public void CountIncreases_ForEmpty_ReturnsZero()
        {
            var input = new int[0];

            var result = Part1.CountIncreases(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountIncreases_ForExample_ReturnsSeven()
        {
            var input = ExampleInput;

            var result = Part1.CountIncreases(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void CountThreeSumIncreases_ForEmpty_ReturnsZero()
        {
            var input = new int[0];

            var result = Part2.CountThreeSumIncreases(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountThreeSumIncreases_ForExample_ReturnsFive()
        {
            var input = ExampleInput;

            var result = Part2.CountThreeSumIncreases(input);

            Assert.AreEqual(5, result);
        }
    }
}
