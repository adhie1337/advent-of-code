namespace AdventOfCode2021.Tests.Days.Day11
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day11.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetFirstRoundWhereInSync_ForExample_Returns195()
        {
            var input = Example.Input;

            var result = GetFirstRoundWhereInSync(input);

            Assert.AreEqual(195, result);
        }
    }
}
