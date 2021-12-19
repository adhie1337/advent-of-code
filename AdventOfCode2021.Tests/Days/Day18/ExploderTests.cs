namespace AdventOfCode2021.Tests.Days.Day18
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day18;
    using static AdventOfCode2021.Days.Day18.Number;
    using static AdventOfCode2021.Days.Day18.Exploder;

    [TestClass]
    public class ExploderTests
    {
        [TestMethod]
        public void Explode_ForNotNeeded_ReturnsDefault()
        {
            var number = Parse("[1,[[[2,3],[4,5]],6]]");

            var result = Explode(number);

            Assert.AreEqual(default(INumber?), result);
        }

        [TestMethod]
        public void Explode_ForInner_ReturnsCorrectNumber()
        {
            var number = Parse("[1,[[[2,[3,9]],[4,5]],6]]");

            var result = Explode(number);

            Assert.AreEqual("[1,[[[5,0],[13,5]],6]]", result?.ToString());
        }

        [TestMethod]
        public void Explode_ForVeryDeep_ExplodesOnlyOnce()
        {
            var number = Parse("[1,[[[2,[3,[9,10]]],[4,5]],6]]");

            var result = Explode(number);

            Assert.AreEqual("[1,[[[2,[12,0]],[14,5]],6]]", result?.ToString());
        }

        [TestMethod]
        public void Explode_ForLeftMost_DisregardsLeftValue()
        {
            var number = Parse("[[[[[1,2],3],4],5],6]");

            var result = Explode(number);

            Assert.AreEqual("[[[[0,5],4],5],6]", result?.ToString());
        }

        [TestMethod]
        public void Explode_ForRightMost_DisregardsRightValue()
        {
            var number = Parse("[1,[2,[3,[4,[5,6]]]]]");

            var result = Explode(number);

            Assert.AreEqual("[1,[2,[3,[9,0]]]]", result?.ToString());
        }
    }
}
