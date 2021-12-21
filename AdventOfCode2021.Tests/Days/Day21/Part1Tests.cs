namespace AdventOfCode2021.Tests.Days.Day21
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day21;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void Simulate_ForExample_Returns739785()
        {
            var input = GameState.Parse(Example.Input, 1000);

            var result = Part1.Simulate(input, new DeterministicDie(100));

            Assert.AreEqual(739785ul, result);
        }
    }
}
