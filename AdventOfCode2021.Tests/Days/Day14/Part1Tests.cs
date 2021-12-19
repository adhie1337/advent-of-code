namespace AdventOfCode2021.Tests.Days.Day14
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day14.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void ApplyStep_ForExample_ReturnsCorrectState()
        {
            var input = Example.State;

            var result = ApplyStep(input).Template.ToString();

            Assert.AreEqual("NCNBCHB", result);
        }

        [TestMethod]
        public void GetResultAfter10Steps_ForExample_ReturnsCorrectState()
        {
            var input = Example.State;

            var result = GetResultAfter10Steps(input);

            Assert.AreEqual(1588L, result);
        }
    }
}
