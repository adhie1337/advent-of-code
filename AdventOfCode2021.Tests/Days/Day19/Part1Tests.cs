namespace AdventOfCode2021.Tests.Days.Day19
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day19.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountBeacons_ForSimplerExample_Returns6()
        {
            var input = Example.Simpler;

            var result = CountBeacons(input, 3);

            Assert.AreEqual(6L, result);
        }

        [TestMethod]
        public void CountBeacons_ForExample_Returns45()
        {
            var input = Example.Scanners;

            var result = CountBeacons(input, 12);

            Assert.AreEqual(79L, result);
        }
    }
}
