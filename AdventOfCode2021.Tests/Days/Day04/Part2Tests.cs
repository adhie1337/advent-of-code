namespace AdventOfCode2021.Tests.Days.Day04
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day04.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CalculateScoreOfLast_ForExample_Returns1924()
        {
            var input = Example.Game;

            var result = CalculateScoreOfLast(input);

            Assert.AreEqual(1924, result);
        }
    }
}
