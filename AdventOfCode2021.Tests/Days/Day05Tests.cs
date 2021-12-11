namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day05;

    [TestClass]
    public class Day05Tests
    {
        private static readonly Line[] ExampleLines = new[]
        {
            new Line(new Point(0, 9), new Point(5, 9)),
            new Line(new Point(8, 0), new Point(0, 8)),
            new Line(new Point(9, 4), new Point(3, 4)),
            new Line(new Point(2, 2), new Point(2, 1)),
            new Line(new Point(7, 0), new Point(7, 4)),
            new Line(new Point(6, 4), new Point(2, 0)),
            new Line(new Point(0, 9), new Point(2, 9)),
            new Line(new Point(3, 4), new Point(1, 4)),
            new Line(new Point(0, 0), new Point(8, 8)),
            new Line(new Point(5, 5), new Point(8, 2)),
        };

        [TestMethod]
        public void CountOverlapPointsWithoutDiagonals_ForExample_Returns5()
        {
            var input = ExampleLines;

            var result = Part1.CountOverlapPointsWithoutDiagonals(input);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void CountOverlappingPoints_ForExample_Returns12()
        {
            var input = ExampleLines;

            var result = Part2.CountOverlappingPoints(input);

            Assert.AreEqual(12, result);
        }
    }
}
