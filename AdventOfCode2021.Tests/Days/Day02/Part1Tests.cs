namespace AdventOfCode2021.Tests.Days.Day02
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day02;
    using static AdventOfCode2021.Days.Day02.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void Simulate_ForEmpty_ReturnsStartPosition()
        {
            var input = new Command[0];

            var result = Simulate(input);

            Assert.AreEqual(Position.Empty, result);
        }

        [TestMethod]
        public void Simulate_ForExample_ReturnsCorrectPosition()
        {
            var input = Example.Commands;

            var result = Simulate(input);

            Assert.AreEqual(new Position(15, 10), result);
        }
    }
}
