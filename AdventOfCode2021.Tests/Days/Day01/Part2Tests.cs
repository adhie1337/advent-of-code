namespace AdventOfCode2021.Tests.Days.Day01
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day01.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountThreeSumIncreases_ForEmpty_ReturnsZero()
        {
            var input = new int[0];

            var result = CountThreeSumIncreases(input);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountThreeSumIncreases_ForExample_ReturnsFive()
        {
            var input = Example.Ints;

            var result = CountThreeSumIncreases(input);

            Assert.AreEqual(5, result);
        }
    }
}
