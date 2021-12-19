namespace AdventOfCode2021.Tests.Days.Day19
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day19.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetMaxDistance_ForExample_Returns3621()
        {
            var input = Example.Scanners;

            var result = GetMaxDistance(input, 12);

            Assert.AreEqual(3621L, result);
        }
    }
}
