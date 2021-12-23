namespace AdventOfCode2021.Tests.Days.Day22
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day22;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountOnCubes_ForSimpleExample_Returns39()
        {
            var input = Example.SimpleInput.Select(Command.Parse).ToArray();

            var result = Part1.CountOnCubes(input);

            Assert.AreEqual(39ul, result);
        }

        [TestMethod]
        public void CountOnCubes_ForExample_Returns590784()
        {
            var input = Example.Input.Select(Command.Parse).ToArray();

            var result = Part1.CountOnCubes(input);

            Assert.AreEqual(590784ul, result);
        }
    }
}
