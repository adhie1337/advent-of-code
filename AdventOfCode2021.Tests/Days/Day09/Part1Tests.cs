namespace AdventOfCode2021.Tests.Days.Day09
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day09.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void GetLowRiskSum_ForExample_Returns15()
        {
            var input = Example.HeightMap;

            var result = GetLowRiskSum(input);

            Assert.AreEqual(15, result);
        }
    }
}
