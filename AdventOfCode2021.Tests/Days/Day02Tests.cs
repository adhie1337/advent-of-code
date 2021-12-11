namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day02;
    using static AdventOfCode2021.Days.Day02.Direction;

    [TestClass]
    public class Day02Tests
    {
        public static readonly Command[] ExampleInput = new[]
        {
            new Command(Forward, 5),
            new Command(Down, 5),
            new Command(Forward, 8),
            new Command(Up, 3),
            new Command(Down, 8),
            new Command(Forward, 2)
        };

        [TestMethod]
        public void Simulate_ForEmpty_ReturnsStartPosition()
        {
            var input = new Command[0];

            var result = Part1.Simulate(input);

            Assert.AreEqual(Position.Empty, result);
        }

        [TestMethod]
        public void Simulate_ForExample_ReturnsCorrectPosition()
        {
            var input = ExampleInput;

            var result = Part1.Simulate(input);

            Assert.AreEqual(new Position(15, 10), result);
        }

        [TestMethod]
        public void Simulate_ForEmpty_ReturnsStartState()
        {
            var input = new Command[0];

            var result = Part2.Simulate(input);

            Assert.AreEqual(State.Start, result);
        }

        [TestMethod]
        public void Simulate_ForExample_ReturnsCorrectState()
        {
            var input = ExampleInput;

            var result = Part2.Simulate(input);

            Assert.AreEqual(new State(15, 60, 10), result);
        }
    }
}
