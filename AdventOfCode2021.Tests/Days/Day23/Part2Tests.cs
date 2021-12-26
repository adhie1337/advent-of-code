namespace AdventOfCode2021.Tests.Days.Day23
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day23;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetEnergyNeeded_ForExample_Returns44169()
        {
            var input = Example.Input;

            var result = Part2.GetEnergyNeeded(input);

            Assert.AreEqual(44169ul, result);
        }
    }
}
