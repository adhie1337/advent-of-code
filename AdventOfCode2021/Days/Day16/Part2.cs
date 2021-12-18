namespace AdventOfCode2021.Days.Day16
{
    using static PacketType;

    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => Evaluate(input[0]);

        public static ulong Evaluate(string input) => new Evaluator().Visit(Packet.ParseHex(input));

        private class Evaluator : PacketVisitor<ulong>
        {
            protected override ulong VisitLiteral(Literal l) => l.Value;

            protected override ulong VisitOperator(Operator o) => o.Type switch
                {
                    Sum => o.SubPackets.Select(this.Visit).Aggregate(0UL, (a, b) => checked(a + b)),
                    Product => o.SubPackets.Select(this.Visit).Aggregate(1UL, (a, b) => checked(a * b)),
                    Minimum => o.SubPackets.Select(this.Visit).Min(),
                    Maximum => o.SubPackets.Select(this.Visit).Max(),
                    GreaterThan => this.Visit(o.SubPackets[0]) > this.Visit(o.SubPackets[1]) ? 1UL : 0,
                    LessThan => this.Visit(o.SubPackets[0]) < this.Visit(o.SubPackets[1]) ? 1UL : 0,
                    EqualTo => this.Visit(o.SubPackets[0]) == this.Visit(o.SubPackets[1]) ? 1UL : 0,
                    _ => throw new InvalidOperationException($"Invalid operator type { o.Type }!"),
                };
        }
    }
}
