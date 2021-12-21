namespace AdventOfCode2021.Tests.Days.Day21
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day21;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CountMostWins_ForExample_Returns444356092776315()
        {
            var input = GameState.Parse(Example.Input, 21);

            var result = Part2.CountMostWins(input);

            Assert.AreEqual(444356092776315ul, result);
        }
    }
}
