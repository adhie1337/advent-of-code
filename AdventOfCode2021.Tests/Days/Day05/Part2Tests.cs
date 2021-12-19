namespace AdventOfCode2021.Tests.Days.Day05
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day05.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountOverlappingPoints_ForExample_Returns12()
        {
            var input = Example.Lines;

            var result = CountOverlappingPoints(input);

            Assert.AreEqual(12, result);
        }
    }
}
