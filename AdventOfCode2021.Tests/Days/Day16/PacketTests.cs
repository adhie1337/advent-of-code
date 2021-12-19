namespace AdventOfCode2021.Tests.Days.Day16
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day16;

    [TestClass]
    public class PacketTests
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
    }
}
