namespace AdventOfCode2021.Tests.Days.Day07
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day07.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CalculateBestPosition_ForExample_Returns168()
        {
            var input = Example.Ints;

            var result = CalculateBestPosition(input);

            Assert.AreEqual(168, result);
        }
    }
}
