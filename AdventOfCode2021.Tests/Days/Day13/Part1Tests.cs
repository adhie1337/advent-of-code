namespace AdventOfCode2021.Tests.Days.Day13
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day13.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountPointsAfterFirst_ForExample_Returns17()
        {
            var input = Example.Sheet;

            var result = CountPointsAfterFirst(input);

            Assert.AreEqual(17, result);
        }
    }
}
