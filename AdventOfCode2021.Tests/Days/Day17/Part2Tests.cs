namespace AdventOfCode2021.Tests.Days.Day17
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day17.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void GetSuccesfulAimCount_ForExample_Returns45()
        {
            var input = Example.TargetArea;

            var result = GetSuccesfulAimCount(input);

            Assert.AreEqual(112, result);
        }
    }
}
