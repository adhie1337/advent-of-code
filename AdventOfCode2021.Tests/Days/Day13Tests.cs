namespace AdventOfCode2021.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day13;
    using static AdventOfCode2021.Days.Day13.FoldDirection;

    [TestClass]
    public class Day13Tests
    {
        public static Sheet ExampleInput = new Sheet()
        {
            Points = new HashSet<Point>()
            {
                new Point(6, 10),
                new Point(0, 14),
                new Point(9, 10),
                new Point(0, 3),
                new Point(10, 4),
                new Point(4, 11),
                new Point(6, 0),
                new Point(6, 12),
                new Point(4, 1),
                new Point(0, 13),
                new Point(10, 12),
                new Point(3, 4),
                new Point(3, 0),
                new Point(8, 4),
                new Point(1, 10),
                new Point(2, 14),
                new Point(8, 10),
                new Point(9, 0),
            },
            Folds = new[]
            {
                new Fold(Up, 7),
                new Fold(Left, 5),
            }
        };

        [TestMethod]
        public void CountPointsAfterFirst_ForExample_Returns17()
        {
            var input = ExampleInput;

            var result = Part1.CountPointsAfterFirst(input);

            Assert.AreEqual(17, result);
        }

        [TestMethod]
        public void PrintResult_ForExample_ReturnsSquare()
        {
            var input = ExampleInput;

            var result = Part2.PrintResult(input);

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
