namespace AdventOfCode2021.Days.Day16
{
    public abstract class PacketVisitor<T>
    {
        public T Visit(IPacket packet)
            => packet switch
            {
                Literal l => this.VisitLiteral(l),
                Operator o => this.VisitOperator(o),
                _ => throw new InvalidDataException($"Invalid packet { packet }!"),
            };

        protected abstract T VisitLiteral(Literal l);

        protected abstract T VisitOperator(Operator o);
    }
}
