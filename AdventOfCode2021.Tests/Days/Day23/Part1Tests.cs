namespace AdventOfCode2021.Tests.Days.Day23
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day23;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void GetEnergyNeeded_ForExample_Returns12521()
        {
            var input = Example.Input;

            var result = Part1.GetEnergyNeeded(input);

            Assert.AreEqual(12521ul, result);
        }
    }
}
