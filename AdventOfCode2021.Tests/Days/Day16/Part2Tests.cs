namespace AdventOfCode2021.Tests.Days.Day16
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day16.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void Evaluate_ForSumExampleString_Returns3()
        {
            var input = "C200B40A82";

            var result = Evaluate(input);

            Assert.AreEqual(3UL, result);
        }

        [TestMethod]
        public void Evaluate_ForProductExampleString_Returns54()
        {
            var input = "04005AC33890";

            var result = Evaluate(input);

            Assert.AreEqual(54UL, result);
        }

        [TestMethod]
        public void Evaluate_ForMinimumExampleString_Returns7()
        {
            var input = "880086C3E88112";

            var result = Evaluate(input);

            Assert.AreEqual(7UL, result);
        }

        [TestMethod]
        public void Evaluate_ForMaximumExampleString_Returns9()
        {
            var input = "CE00C43D881120";

            var result = Evaluate(input);

            Assert.AreEqual(9UL, result);
        }

        [TestMethod]
        public void Evaluate_ForLessThanExampleString_Returns1()
        {
            var input = "D8005AC2A8F0";

            var result = Evaluate(input);

            Assert.AreEqual(1UL, result);
        }

        [TestMethod]
        public void Evaluate_ForGreaterThanExampleString_Returns0()
        {
            var input = "F600BC2D8F";

            var result = Evaluate(input);

            Assert.AreEqual(0UL, result);
        }

        [TestMethod]
        public void Evaluate_ForEqualToExampleString_Returns0()
        {
            var input = "9C005AC2F8F0";

            var result = Evaluate(input);

            Assert.AreEqual(0UL, result);
        }

        [TestMethod]
        public void Evaluate_ForComplexExampleString_Returns1()
        {
            var input = "9C0141080250320F1802104A08";

            var result = Evaluate(input);

            Assert.AreEqual(1UL, result);
        }
    }
}
