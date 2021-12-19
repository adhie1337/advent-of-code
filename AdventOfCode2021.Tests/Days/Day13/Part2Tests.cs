namespace AdventOfCode2021.Tests.Days.Day13
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day13.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void PrintResult_ForExample_ReturnsSquare()
        {
            var input = Example.Sheet;

            var result = PrintResult(input);

            var expected = @"
#####
#   #
#   #
#   #
#####
".TrimStart();
            Assert.AreEqual(expected, result);
        }
    }
}
