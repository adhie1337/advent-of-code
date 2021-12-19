namespace AdventOfCode2021.Tests.Days.Day16
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day16.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void SumVersionNumbers_ForFirstExample_Returns16()
        {
            var input = "8A004A801A8002F478";

            var result = SumVersionNumbers(input);

            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForSecondExample_Returns12()
        {
            var input = "620080001611562C8802118E34";

            var result = SumVersionNumbers(input);

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForThirdExample_Returns23()
        {
            var input = "C0015000016115A2E0802F182340";

            var result = SumVersionNumbers(input);

            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForFourthExample_Returns31()
        {
            var input = "A0016C880162017C3686B18A3D4780";

            var result = SumVersionNumbers(input);

            Assert.AreEqual(31, result);
        }
    }
}
