namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day16;

    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void ParseHex_LiteralString_ReturnsLiteral()
        {
            var input = "D2FE28";

            var result = Packet.ParseHex(input);

            Assert.AreEqual(new Literal(6, 7 * 16 * 16 + 14 * 16 + 5), result);
        }

        [TestMethod]
        public void ParseHex_OperatorString_ReturnsOperator()
        {
            var input = "38006F45291200";

            var result = Packet.ParseHex(input);

            var expected = new Operator()
            {
                Version = 1,
                Type = PacketType.LessThan,
                SubPackets = new IPacket[]
                {
                    new Literal(6, 10),
                    new Literal(2, 20),
                }
            };
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Parse_OtherOperatorString_ReturnsOperator()
        {
            var input = "EE00D40C823060";

            var result = Packet.ParseHex(input);

            var expected = new Operator()
            {
                Version = 7,
                Type = PacketType.Maximum,
                SubPackets = new IPacket[]
                {
                    new Literal(2, 1),
                    new Literal(4, 2),
                    new Literal(1, 3),
                }
            };
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForFirstExample_Returns16()
        {
            var input = "8A004A801A8002F478";

            var result = Part1.SumVersionNumbers(input);

            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForSecondExample_Returns12()
        {
            var input = "620080001611562C8802118E34";

            var result = Part1.SumVersionNumbers(input);

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForThirdExample_Returns23()
        {
            var input = "C0015000016115A2E0802F182340";

            var result = Part1.SumVersionNumbers(input);

            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void SumVersionNumbers_ForFourthExample_Returns31()
        {
            var input = "A0016C880162017C3686B18A3D4780";

            var result = Part1.SumVersionNumbers(input);

            Assert.AreEqual(31, result);
        }

        [TestMethod]
        public void Evaluate_ForSumExampleString_Returns3()
        {
            var input = "C200B40A82";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(3UL, result);
        }

        [TestMethod]
        public void Evaluate_ForProductExampleString_Returns54()
        {
            var input = "04005AC33890";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(54UL, result);
        }

        [TestMethod]
        public void Evaluate_ForMinimumExampleString_Returns7()
        {
            var input = "880086C3E88112";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(7UL, result);
        }

        [TestMethod]
        public void Evaluate_ForMaximumExampleString_Returns9()
        {
            var input = "CE00C43D881120";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(9UL, result);
        }

        [TestMethod]
        public void Evaluate_ForLessThanExampleString_Returns1()
        {
            var input = "D8005AC2A8F0";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(1UL, result);
        }

        [TestMethod]
        public void Evaluate_ForGreaterThanExampleString_Returns0()
        {
            var input = "F600BC2D8F";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(0UL, result);
        }

        [TestMethod]
        public void Evaluate_ForEqualToExampleString_Returns0()
        {
            var input = "9C005AC2F8F0";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(0UL, result);
        }

        [TestMethod]
        public void Evaluate_ForComplexExampleString_Returns1()
        {
            var input = "9C0141080250320F1802104A08";

            var result = Part2.Evaluate(input);

            Assert.AreEqual(1UL, result);
        }
    }
}
