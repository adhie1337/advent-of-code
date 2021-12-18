namespace AdventOfCode2021.Days.Day16
{
    using System.Text;

    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => SumVersionNumbers(input[0]);

        public static string ToBinary(string hexString)
        {
            var result = new StringBuilder();

            foreach (var c in hexString) result.Append(Convert.ToString(Convert.ToByte(c.ToString(), 16), 2).PadLeft(4, '0'));

            return result.ToString();
        }

        public static int SumVersionNumbers(string input) => new VersionNumberSumVisitor().Visit(Packet.Parse(ToBinary(input)));

        private class VersionNumberSumVisitor : PacketVisitor<int>
        {
            protected override int VisitLiteral(Literal l) => l.Version;

            protected override int VisitOperator(Operator o) => o.Version + o.SubPackets.Sum(this.Visit);
        }
    }
}
