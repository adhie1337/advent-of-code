namespace AdventOfCode2021.Tests.Days.Day20
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day20;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountPixelsAfter50Enhancements_ForExample_Returns3351()
        {
            var input = Example.Image;

            var result = Part2.CountPixelsAfter(input, 50);

            Assert.AreEqual(3351L, result);
        }
    }
}
