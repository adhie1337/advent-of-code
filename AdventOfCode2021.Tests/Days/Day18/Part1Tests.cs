namespace AdventOfCode2021.Tests.Days.Day18
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day18.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void GetSumMagnitude_ForExample_Returns4140()
        {
            var input = Example.Homework;

            var result = GetSumMagnitude(input);

            Assert.AreEqual(4140ul, result);
        }
    }
}
