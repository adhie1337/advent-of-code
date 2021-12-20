namespace AdventOfCode2021.Tests.Days.Day20
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day20;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountPixelsAfter2Enhancements_ForExample_Returns35()
        {
            var input = Example.Image;

            var result = Part1.CountPixelsAfter(input, 2);

            Assert.AreEqual(35L, result);
        }
    }
}
