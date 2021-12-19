namespace AdventOfCode2021.Tests.Days.Day09
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day09.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetBasinSizes_ForExample_Returns1134()
        {
            var input = Example.HeightMap;

            var result = GetBasinSizes(input);

            Assert.AreEqual(1134, result);
        }
    }
}
