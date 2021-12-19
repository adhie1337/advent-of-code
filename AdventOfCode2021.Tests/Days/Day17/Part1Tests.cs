namespace AdventOfCode2021.Tests.Days.Day17
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day17.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void GetHighestY_ForExample_Returns45()
        {
            var input = Example.TargetArea;

            var result = GetHighestY(input);

            Assert.AreEqual(45, result);
        }
    }
}
