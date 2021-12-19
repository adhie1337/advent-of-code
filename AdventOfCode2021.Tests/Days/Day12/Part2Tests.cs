namespace AdventOfCode2021.Tests.Days.Day12
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day12.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountPaths_ForSmallExample_Returns36()
        {
            var input = Example.SmallInput;

            var result = CountPaths(input);

            Assert.AreEqual(36ul, result);
        }

        [TestMethod]
        public void CountPaths_ForSlightlyLargerExample_Returns103()
        {
            var input = Example.SlightlyLargerInput;

            var result = CountPaths(input);

            Assert.AreEqual(103ul, result);
        }

        [TestMethod]
        public void CountPaths_ForLargerExample_Returns3509()
        {
            var input = Example.LargerInput;

            var result = CountPaths(input);

            Assert.AreEqual(3509ul, result);
        }
    }
}
