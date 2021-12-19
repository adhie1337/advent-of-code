namespace AdventOfCode2021.Days.Day18
{
    public abstract class NumberVisitor<T>
    {
        public T VisitNumber(INumber number)
            => number switch
            {
                Literal literal => this.VisitLiteral(literal),
                Pair pair => this.VisitPair(pair),
                _ => throw new InvalidDataException($@"Unexpected number ""{ number }""!"),
            };

        public abstract T VisitLiteral(Literal literal);

        public abstract T VisitPair(Pair pair);
    }

    public abstract class NumberVisitor<TParam, TResult>
    {
        public TResult VisitNumber(INumber number, TParam param)
            => number switch
            {
                Literal literal => this.VisitLiteral(literal, param),
                Pair pair => this.VisitPair(pair, param),
                _ => throw new InvalidDataException($@"Unexpected number ""{ number }""!"),
            };

        public abstract TResult VisitLiteral(Literal literal, TParam param);

        public abstract TResult VisitPair(Pair pair, TParam param);
    }

    public class Exploder : NumberVisitor<int, (byte?, INumber?, byte?)>
    {
        private static readonly Exploder Instance = new Exploder();

        public static INumber? Explode(INumber number) => Instance.VisitNumber(number, 1).Item2;

        public override (byte?, INumber?, byte?) VisitLiteral(Literal literal, int _) => default;

        public override (byte?, INumber?, byte?) VisitPair(Pair pair, int depth)
        {
            if (pair.Left is Literal left && pair.Right is Literal right && depth > 4)
            {
                return (left.Value, new Literal(0), right.Value);
            }
            else if (this.VisitNumber(pair.Left, depth + 1) is (var ll, INumber ln, var lr))
            {
                return (ll, new Pair(ln, this.AddToLeft(pair.Right, lr)), null);
            }
            else if (this.VisitNumber(pair.Right, depth + 1) is (var rl, INumber rn, var rr))
            {
                return (null, new Pair(this.AddToRigth(pair.Left, rl), rn), rr);
            }

            return default;
        }

        public INumber AddToLeft(INumber number, byte? addition)
            => (number, addition) switch
            {
                (Literal(var value), byte a) when a > 0 => new Literal((byte)(value + a)),
                (Pair(var left, var right), byte b) when b > 0 => new Pair(this.AddToLeft(left, b), right),
                _ => number,
            };

        public INumber AddToRigth(INumber number, byte? addition)
            => (number, addition) switch
            {
                (Literal(var value), byte a) when a > 0 => new Literal((byte)(value + a)),
                (Pair(var left, var right), byte b) when b > 0 => new Pair(left, this.AddToRigth(right, b)),
                _ => number,
            };
    }

    public class Splitter : NumberVisitor<INumber?>
    {
        private static readonly Splitter Instance = new Splitter();

        public static INumber? Split(INumber number) => Instance.VisitNumber(number);

        public override INumber? VisitLiteral(Literal literal)
        {
            if (literal.Value < 10) return default;

            var half = (byte)Math.Floor(literal.Value / 2.0);
            var left = new Literal(half);
            var right = new Literal(half * 2 == literal.Value ? half : (byte)(half + 1));

            return new Pair(left, right);
        }

        public override INumber? VisitPair(Pair pair)
        {
            var left = this.VisitNumber(pair.Left);

            if (left is INumber leftSplitted) return new Pair(leftSplitted, pair.Right);

            var right = this.VisitNumber(pair.Right);

            if (right is INumber rightSplitted) return new Pair(pair.Left, rightSplitted);

            return default;
        }
    }
}
