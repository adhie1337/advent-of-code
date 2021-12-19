namespace AdventOfCode2021.Tests.Days.Day05
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day05.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountOverlapPointsWithoutDiagonals_ForExample_Returns5()
        {
            var input = Example.Lines;

            var result = CountOverlapPointsWithoutDiagonals(input);

            Assert.AreEqual(5, result);
        }
    }
}
