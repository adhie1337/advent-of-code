namespace AdventOfCode2021.Tests.Days.Day04
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day04.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CalclateScoreOfWinner_ForExample_Returns4512()
        {
            var input = Example.Game;

            var result = CalclateScoreOfWinner(input);

            Assert.AreEqual(4512, result);
        }
    }
}
