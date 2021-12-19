namespace AdventOfCode2021.Tests.Days.Day10
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day10.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CalculateAutocompleteScore_ForExample_Returns288957()
        {
            var input = Example.Input;

            var result = CalculateAutocompleteScore(input);

            Assert.AreEqual(288957ul, result);
        }
    }
}
