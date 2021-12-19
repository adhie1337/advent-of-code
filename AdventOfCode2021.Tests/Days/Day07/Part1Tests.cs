namespace AdventOfCode2021.Tests.Days.Day07
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day07.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CalculateBestPosition_ForExample_Returns37()
        {
            var input = Example.Ints;

            var result = CalculateBestPosition(input);

            Assert.AreEqual(37, result);
        }
    }
}
