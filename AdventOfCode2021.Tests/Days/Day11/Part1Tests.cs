namespace AdventOfCode2021.Tests.Days.Day11
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day11.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountFlashes_ForExample_Returns1656()
        {
            var input = Example.Input;

            var result = CountFlashes(input);

            Assert.AreEqual(1656ul, result);
        }
    }
}
