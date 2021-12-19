namespace AdventOfCode2021.Tests.Days.Day03
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day03;
    using static AdventOfCode2021.Days.Day03.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CalculatePowerConsumpltionReport_ForEmpty_ReturnsEmptyReport()
        {
            var input = new string[0];

            var result = CalculatePowerConsumpltionReport(input);

            Assert.AreEqual(new PowerConsumpltionReport(), result);
        }

        [TestMethod]
        public void CalculatePowerConsumpltionReport_ForExample_ReturnsCorrectReport()
        {
            var input = Example.Input;

            var result = CalculatePowerConsumpltionReport(input);

            Assert.AreEqual(new PowerConsumpltionReport(22, 9), result);
        }
    }
}
