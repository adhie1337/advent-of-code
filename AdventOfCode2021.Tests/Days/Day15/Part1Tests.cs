namespace AdventOfCode2021.Tests.Days.Day15
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day15.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void GetLowRiskPath_ForExample_ReturnsCorrectLength()
        {
            var input = Parse(Example.Input);

            var result = GetLowRiskPath(input);

            Assert.AreEqual(40ul, result);
        }
    }
}
