namespace AdventOfCode2021.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day14;

    [TestClass]
    public class Day14Tests
    {
        public static PolimerizationState ExampleInput = new PolimerizationState()
        {
            Template = "NNCB",
            Rules = new Dictionary<(char, char), char>()
            {
                { ('C', 'H'), 'B' },
                { ('H', 'H'), 'N' },
                { ('C', 'B'), 'H' },
                { ('N', 'H'), 'C' },
                { ('H', 'B'), 'C' },
                { ('H', 'C'), 'B' },
                { ('H', 'N'), 'C' },
                { ('N', 'N'), 'C' },
                { ('B', 'H'), 'H' },
                { ('N', 'C'), 'B' },
                { ('N', 'B'), 'B' },
                { ('B', 'N'), 'B' },
                { ('B', 'B'), 'N' },
                { ('B', 'C'), 'B' },
                { ('C', 'C'), 'N' },
                { ('C', 'N'), 'C' },
            }
        };

        [TestMethod]
        public void ApplyStep_ForExample_ReturnsCorrectState()
        {
            var input = ExampleInput;

            var result = Part1.ApplyStep(input).Template.ToString();

            Assert.AreEqual("NCNBCHB", result);
        }

        [TestMethod]
        public void GetResultAfter10Steps_ForExample_ReturnsCorrectState()
        {
            var input = ExampleInput;

            var result = Part1.GetResultAfter10Steps(input);

            Assert.AreEqual(1588L, result);
        }

        [TestMethod]
        public async Task SimulateCharCounts_ForExampleAnd10Times_ReturnsCorrectState()
        {
            var input = ExampleInput;

            var result = await Part2.SimulateCharCounts(input, 10);

            Assert.AreEqual(1588ul, result.Max() - result.Min());
        }

        [TestMethod]
        public async Task GetResultAfter40Steps_ForExample_ReturnsCorrectState()
        {
            var input = ExampleInput;

            var result = await Part2.GetResultAfter40Steps(input);

            Assert.AreEqual(2188189693529ul, result);
        }
    }
}
