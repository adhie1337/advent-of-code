namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day09;

    [TestClass]
    public class Day09Tests
    {
        private static readonly HeightMap Example = new HeightMap()
        {
            Heights = new byte[,]
            {
                { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
                { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
                { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
                { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
                { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
            }
        };

        [TestMethod]
        public void GetLowRiskSum_ForExample_Returns15()
        {
            var input = Example;

            var result = Part1.GetLowRiskSum(input);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GetBasinSizes_ForExample_Returns1134()
        {
            var input = Example;

            var result = Part2.GetBasinSizes(input);

            Assert.AreEqual(1134, result);
        }
    }
}
