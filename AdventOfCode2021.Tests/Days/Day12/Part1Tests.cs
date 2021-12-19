namespace AdventOfCode2021.Tests.Days.Day12
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day12.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountPaths_ForSmallExample_Returns10()
        {
            var input = Example.SmallInput;

            var result = CountPaths(input);

            Assert.AreEqual(10ul, result);
        }

        [TestMethod]
        public void CountPaths_ForSlightlyLargerExample_Returns19()
        {
            var input = Example.SlightlyLargerInput;

            var result = CountPaths(input);

            Assert.AreEqual(19ul, result);
        }

        [TestMethod]
        public void CountPaths_ForLargerExample_Returns226()
        {
            var input = Example.LargerInput;

            var result = CountPaths(input);

            Assert.AreEqual(226ul, result);
        }
    }
}
