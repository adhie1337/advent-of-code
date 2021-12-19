namespace AdventOfCode2021.Tests.Days.Day06
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day06.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CalculateSchoolSize_ForExample_Returns5934()
        {
            var input = Example.LanternFishes;

            var result = CalculateSchoolSize(input);

            Assert.AreEqual(5934, result);
        }
    }
}
