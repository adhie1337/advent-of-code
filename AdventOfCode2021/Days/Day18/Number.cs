namespace AdventOfCode2021.Days.Day18
{
    using System.Text;

    public interface INumber
    {
        ulong Magnitude { get; }
    }

    public readonly record struct Literal(byte Value) : INumber
    {
        public ulong Magnitude => this.Value;

        public override string ToString() => Number.Print(this);
    }

    public readonly record struct Pair(INumber Left, INumber Right) : INumber
    {
        public ulong Magnitude => checked(3 * this.Left.Magnitude + 2 * this.Right.Magnitude);

        public override string ToString() => Number.Print(this);
    }

    public static class Number
    {
        public static INumber Pair(byte left, byte right) => new Pair(new Literal(left), new Literal(right));

        public static INumber Pair(INumber left, byte right) => new Pair(left, new Literal(right));

        public static INumber Pair(byte left, INumber right) => new Pair(new Literal(left), right);

        public static INumber Pair(INumber left, INumber right) => new Pair(left, right);

        public static INumber Add(INumber left, INumber right) => Reduce(Pair(left, right));

        public static INumber Reduce(INumber original)
            => Exploder.Explode(original) is INumber exploded ? Reduce(exploded)
            : Splitter.Split(original) is INumber splitted ? Reduce(splitted)
            : original;

        public static INumber Parse(string input) => ReadNumber(input).Result;

        public static (INumber Result, int NextIndex) ReadNumber(ReadOnlySpan<char> input)
            => input[0] switch
            {
                '[' => ReadPair(input),
                var c when Char.IsDigit(c) => ReadLiteral(input),
                _ => throw new InvalidDataException($@"Unexpected character at first of ""{ input }""!"),
            };

        public static (INumber, int) ReadPair(ReadOnlySpan<char> input)
        {
            static void Check(ReadOnlySpan<char> input, int actIndex, char expected)
            {
                var found = input.Length <= actIndex ? "end of string" : input[actIndex].ToString();
                if (found == expected.ToString()) return;
                var message = $@"Unexpected character at { actIndex } of ""{ input }"" ({ found }), expected '{ expected }'!";
                throw new InvalidDataException(message);
            }

            var actIndex = 0;
            Check(input, actIndex, '[');
            actIndex++;

            var (left, commaIndex) = ReadNumber(input[actIndex..]);
            actIndex += commaIndex;
            Check(input, actIndex, ',');
            actIndex++;

            var (right, closeIndex) = ReadNumber(input[actIndex..]);
            actIndex += closeIndex;
            Check(input, actIndex, ']');

            return (new Pair(left, right), commaIndex + closeIndex + 3);
        }

        public static (INumber, int) ReadLiteral(ReadOnlySpan<char> input)
        {
            var i = 0;

            while (Char.IsDigit(input[i])) ++i;

            return (new Literal(byte.Parse(input[0..i])), i);
        }

        public static string Print(INumber number) => new StringBuilder().AppendNumber(number).ToString();

        public static StringBuilder AppendNumber(this StringBuilder stringBuilder, INumber number)
            => number switch
            {
                Literal literal => stringBuilder.AppendLiteral(literal),
                Pair pair => stringBuilder.AppendPair(pair),
                _ => throw new InvalidDataException($@"Unexpected number ""{ number }""!"),
            };

        public static StringBuilder AppendLiteral(this StringBuilder stringBuilder, Literal literal)
        {
            stringBuilder.Append(literal.Value);

            return stringBuilder;
        }

        public static StringBuilder AppendPair(this StringBuilder stringBuilder, Pair pair)
        {
            stringBuilder.Append('[');
            stringBuilder.AppendNumber(pair.Left);
            stringBuilder.Append(',');
            stringBuilder.AppendNumber(pair.Right);
            stringBuilder.Append(']');

            return stringBuilder;
        }
    }
}
