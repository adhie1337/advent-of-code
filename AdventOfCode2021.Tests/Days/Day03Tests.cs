namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day03;

    [TestClass]
    public class Day03Tests
    {
        private static readonly string[] ExampleInput = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

        [TestMethod]
        public void CalculatePowerConsumpltionReport_ForEmpty_ReturnsCorrectReport()
        {
            var input = new string[0];

            var result = Part1.CalculatePowerConsumpltionReport(input);

            Assert.AreEqual(new PowerConsumpltionReport(0, 0), result);
        }

        [TestMethod]
        public void CalculatePowerConsumpltionReport_ForExampleInput_ReturnsEmptyReport()
        {
            var input = ExampleInput;

            var result = Part1.CalculatePowerConsumpltionReport(input);

            Assert.AreEqual(new PowerConsumpltionReport(22, 9), result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForSingletonList_ReturnsReportOfOnes()
        {
            var input = new[] { "1" };

            var result = Part2.CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(1, 1), result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForDualList_ReturnsCorrectReport()
        {
            var input = new[] { "1", "0" };

            var result = Part2.CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(1, 0), result);
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

        [TestMethod]
        public void CalculateLifeSupportReport_ForEmpty_ReturnsCorrectReport()
        {
            var input = new string[0];

            var result = Part2.CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(0, 0), result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForExampleInput_ReturnsEmptyReport()
        {
            var input = ExampleInput;

            var result = Part2.CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(23, 10), result);
        }
    }
}
