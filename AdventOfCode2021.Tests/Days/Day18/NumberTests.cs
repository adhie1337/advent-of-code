namespace AdventOfCode2021.Tests.Days.Day18
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day18.Number;

    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void Print_ForExample_ReturnsCorrectString()
        {
            var number = Pair(1, Pair(Pair(2, 3), 4));

            var result = Print(number);

            Assert.AreEqual("[1,[[2,3],4]]", result);
        }

        [TestMethod]
        public void Parse_ForExample_ReturnsCorrectNumber()
        {
            var input = "[1,[[[2,3],[4,5]],6]]";

            var result = Parse(input);

            Assert.AreEqual(Pair(1, Pair(Pair(Pair(2, 3), Pair(4, 5)), 6)), result);
        }

        [TestMethod]
        public void Add_ForExample_ReturnsCorrectNumber()
        {
            var left = Parse("[[[[4,3],4],4],[7,[[8,4],9]]]");
            var right = Parse("[1,1]");

            var result = Add(left, right);

            Assert.AreEqual("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", result.ToString());
        }

        [TestMethod]
        public void Add_ForLargeExample_ReturnsCorrectNumber()
        {
            var left = Parse("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]");
            var right = Parse("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]");

            var result = Add(left, right);

            Assert.AreEqual("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]", result.ToString());
        }
    }
}
