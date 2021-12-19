namespace AdventOfCode2021.Tests.Days.Day18
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day18.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetMaxMagnitudeOfPairsAdded_ForExample_Returns3993()
        {
            var input = Example.Homework;

            var result = GetMaxMagnitudeOfPairsAdded(input);

            Assert.AreEqual(3993ul, result);
        }
    }
}
