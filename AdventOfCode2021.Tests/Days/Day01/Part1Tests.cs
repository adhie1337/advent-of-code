namespace AdventOfCode2021.Tests.Days.Day01
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day01.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountIncreases_ForEmpty_ReturnsZero()
        {
            var input = new int[0];

            var result = CountIncreases(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountIncreases_ForExample_ReturnsSeven()
        {
            var input = Example.Ints;

            var result = CountIncreases(input);

            Assert.AreEqual(7, result);
        }
    }
}
