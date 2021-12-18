namespace AdventOfCode2021.Days.Day16
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => SumVersionNumbers(input[0]);

        public static int SumVersionNumbers(string input) => new VersionNumberSumVisitor().Visit(Packet.ParseHex(input));

        private class VersionNumberSumVisitor : PacketVisitor<int>
        {
            protected override int VisitLiteral(Literal l) => l.Version;

            protected override int VisitOperator(Operator o) => o.Version + o.SubPackets.Sum(this.Visit);
        }
    }
}
