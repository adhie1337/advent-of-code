namespace AdventOfCode2021.Tests.Days.Day06
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day06.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void CalculateFishSchoolSize_ForExample_Returns26984457539()
        {
            var input = Example.School;

            var result = CalculateFishSchoolSize(input);

            Assert.AreEqual(26984457539ul, result);
        }
    }
}
