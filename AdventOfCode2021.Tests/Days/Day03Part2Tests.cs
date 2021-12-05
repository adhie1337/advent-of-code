namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day03;

    [TestClass]
    public class Day03Part2Tests
    {
        [TestMethod]
        public void Apply_ForSingletonList_ReturnsOnlyValue()
        {
            var input = new[] { "1" };

            var result = Part2.Compute(input);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Apply_ForDualList_ReturnsZeroValue()
        {
            var input = new[] { "1", "0" };

            var result = Part2.Compute(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetOxigenGeneratorRating_ForFairlyComplexList_ReturnsCorrectValue()
        {
            var input = new[] { "110", "100", "111" };

            var result = Part2.GetOxigenGeneratorRating(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetCo2ScrubberRating_ForFairlyComplexList_ReturnsCorrectValue()
        {
            var input = new[] { "110", "100", "111" };

            var result = Part2.GetCo2ScrubberRating(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetOxigenGeneratorRating_ForExampleList_ReturnsCorrectValue()
        {
            var input = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = Part2.GetOxigenGeneratorRating(input);

            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void GetCo2ScrubberRating_ForExampleList_ReturnsCorrectValue()
        {
            var input = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = Part2.GetCo2ScrubberRating(input);

            Assert.AreEqual(10, result);
        }
    }
}
