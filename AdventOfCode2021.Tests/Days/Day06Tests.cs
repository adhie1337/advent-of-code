namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day06;

    [TestClass]
    public class Day06Tests
    {
        private static readonly LanternFish[] ExampleLanternFishes = new[]
        {
            new LanternFish(3),
            new LanternFish(4),
            new LanternFish(3),
            new LanternFish(1),
            new LanternFish(2),
        };

        private static readonly LanternFishSchool ExampleSchool = new LanternFishSchool(new ulong[] { 0, 1, 1, 2, 1, 0, 0, 0, 0, 0 });

        [TestMethod]
        public void CountOverlapPointsWithoutDiagonals_ForExampleInput_Returns5934()
        {
            var input = ExampleLanternFishes;

            var result = Part1.CalculateSchoolSize(input);

            Assert.AreEqual(5934, result);
        }

        [TestMethod]
        public void CalculateFishSchoolSize_ForExampleInput_Returns26984457539()
        {
            var input = ExampleSchool;

            var result = Part2.CalculateFishSchoolSize(input);

            Assert.AreEqual<ulong>(26984457539, result);
        }
    }
}
