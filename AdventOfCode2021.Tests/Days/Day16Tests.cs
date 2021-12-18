namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day16;

    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void Parse_LiteralString_ReturnsLiteral()
        {
            var input = Part1.ToBinary("D2FE28");

            var result = Packet.Parse(input);

            Assert.AreEqual(new Literal(6, 7 * 16 * 16 + 14 * 16 + 5), result);
        }

        [TestMethod]
        public void Parse_OperatorString_ReturnsOperator()
        {
            var input = Part1.ToBinary("38006F45291200");

            var result = Packet.Parse(input);

            var expected = new Operator()
            {
                Version = 1,
                Type = (PacketType)6,
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
            var input = Part1.ToBinary("EE00D40C823060");

            var result = Packet.Parse(input);

            var expected = new Operator()
            {
                Version = 7,
                Type = (PacketType)3,
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
    }
}
