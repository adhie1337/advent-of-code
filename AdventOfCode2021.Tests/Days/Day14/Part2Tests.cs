namespace AdventOfCode2021.Tests.Days.Day14
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day14.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public async Task SimulateCharCounts_ForExampleAnd10Times_ReturnsCorrectState()
        {
            var input = Example.State;

            var result = await SimulateCharCounts(input, 10);

            Assert.AreEqual(1588ul, result.Max() - result.Min());
        }

        [TestMethod]
        public async Task GetResultAfter40Steps_ForExample_ReturnsCorrectState()
        {
            var input = Example.State;

            var result = await GetResultAfter40Steps(input);

            Assert.AreEqual(2188189693529ul, result);
        }
    }
}
