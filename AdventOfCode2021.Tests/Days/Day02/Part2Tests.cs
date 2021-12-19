namespace AdventOfCode2021.Tests.Days.Day02
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day02;
    using static AdventOfCode2021.Days.Day02.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void Simulate_ForEmpty_ReturnsStartState()
        {
            var input = new Command[0];

            var result = Simulate(input);

            Assert.AreEqual(State.Start, result);
        }

        [TestMethod]
        public void Simulate_ForExample_ReturnsCorrectState()
        {
            var input = Example.Commands;

            var result = Simulate(input);

            Assert.AreEqual(new State(15, 60, 10), result);
        }
    }
}
