namespace AdventOfCode2021.Tests.Days.Day18
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day18;
    using static AdventOfCode2021.Days.Day18.Number;
    using static AdventOfCode2021.Days.Day18.Splitter;

    [TestClass]
    public class SplitterTests
    {
        [TestMethod]
        public void Split_ForNotNeeded_ReturnsDefault()
        {
            var number = Parse("[1,[[[2,3],[4,5]],6]]");

            var result = Split(number);

            Assert.AreEqual(default(INumber?), result);
        }

        [TestMethod]
        public void Split_ForSplittable_ReturnsCorrectNumber()
        {
            var number = Parse("[1,[[[2,[3,11]],[4,5]],6]]");

            var result = Split(number);

            Assert.AreEqual("[1,[[[2,[3,[5,6]]],[4,5]],6]]", result?.ToString());
        }

        [TestMethod]
        public void Split_ForSplittableMoreThanOnce_SplitsOnlyOnce()
        {
            var number = Parse("[10,[[[2,[3,11]],[4,5]],6]]");

            var result = Split(number);

            Assert.AreEqual("[[5,5],[[[2,[3,11]],[4,5]],6]]", result?.ToString());
        }

        [TestMethod]
        public void Split_ForHugeSplittable_SplitsOnlyOnce()
        {
            var number = Parse("[9,19]");

            var result = Split(number);

            Assert.AreEqual("[9,[9,10]]", result?.ToString());
        }
    }
}
