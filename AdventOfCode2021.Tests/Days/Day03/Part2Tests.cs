namespace AdventOfCode2021.Tests.Days.Day03
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day03;
    using static AdventOfCode2021.Days.Day03.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CalculateLifeSupportReport_ForSingletonList_ReturnsReportOfOnes()
        {
            var input = new[] { "1" };

            var result = CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(1, 1), result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForDualList_ReturnsCorrectReport()
        {
            var input = new[] { "1", "0" };

            var result = CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(1, 0), result);
        }

        [TestMethod]
        public void GetOxigenGeneratorRate_ForFairlyComplexList_ReturnsCorrectValue()
        {
            var input = new[] { "110", "100", "111" };

            var result = GetOxigenGeneratorRate(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetCo2ScrubberRate_ForFairlyComplexList_ReturnsCorrectValue()
        {
            var input = new[] { "110", "100", "111" };

            var result = GetCo2ScrubberRate(input);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetOxigenGeneratorRate_ForExampleList_ReturnsCorrectValue()
        {
            var input = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = GetOxigenGeneratorRate(input);

            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void GetCo2ScrubberRate_ForExampleList_ReturnsCorrectValue()
        {
            var input = new[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = GetCo2ScrubberRate(input);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForEmpty_ReturnsEmptyReport()
        {
            var input = new string[0];

            var result = CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(), result);
        }

        [TestMethod]
        public void CalculateLifeSupportReport_ForExample_ReturnsCorrectReport()
        {
            var input = Example.Input;

            var result = CalculateLifeSupportReport(input);

            Assert.AreEqual(new LifeSupportReport(23, 10), result);
        }
    }
}
