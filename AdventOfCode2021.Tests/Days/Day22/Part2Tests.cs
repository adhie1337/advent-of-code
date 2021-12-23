namespace AdventOfCode2021.Tests.Days.Day22
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day22;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountOnCubes_ForPart2Example_Returns2758514936282235()
        {
            var input = Example.Part2Input.Select(AdventOfCode2021.Days.Day22.Command.Parse).ToArray();

            var result = Part2.CountOnCubes(input);

            Assert.AreEqual(2758514936282235ul, result);
        }
    }
}
