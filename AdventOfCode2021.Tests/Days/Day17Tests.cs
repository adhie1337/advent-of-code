namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day17;

    [TestClass]
    public class Day17Tests
    {
        public readonly TargetArea Example = new TargetArea(20, 30, -5, -10);

        [TestMethod]
        public void GetHighestY_ForExample_Returns45()
        {
            var input = Example;

            var result = Part1.GetHighestY(input);

            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void GetSuccesfulAimCount_ForExample_Returns45()
        {
            var input = Example;

            var result = Part2.GetSuccesfulAimCount(input);

            Assert.AreEqual(112, result);
        }
    }
}
