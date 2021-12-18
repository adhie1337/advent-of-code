namespace AdventOfCode2021.Days.Day16
{
    using System.Text;

    public enum PacketType : byte
    {
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        Literal = 4,
        GreaterThan = 5,
        LessThan = 6,
        EqualTo = 7,
    }

    public interface IPacket
    {
        byte Version { get; }

        PacketType Type { get; }
    }

    public readonly record struct Literal(byte Version, ulong Value) : IPacket
    {
        public PacketType Type => PacketType.Literal;
    }

    public readonly record struct Operator(byte Version, PacketType Type, IPacket[] SubPackets) : IPacket
    {
        public override string ToString()
            => $@"Operator {{ Version = { this.Version }, Type = { this.Type }, SubPackets = [{ string.Join(", ", this.SubPackets.Select(_ => _.ToString())) }]}}";

        public bool Equals(Operator other)
            => other is Operator o && this.Version == o.Version && this.Type == o.Type && this.SubPackets.SequenceEqual(o.SubPackets);

        public override int GetHashCode()
            => this.SubPackets.OfType<object>()
                .Prepend(this.Type)
                .Prepend(this.Version)
                .Aggregate(new HashCode(), (h, a) => { h.Add(a); return h; })
                .ToHashCode();
    }

    public static class Packet
    {
        public static string ToBinary(string hexString)
        {
            var result = new StringBuilder();

            foreach (var c in hexString) result.Append(Convert.ToString(Convert.ToByte(c.ToString(), 16), 2).PadLeft(4, '0'));

            return result.ToString();
        }

        public static IPacket ParseHex(string input) => Parse(ToBinary(input));

        public static IPacket Parse(string input) => ReadPacket(input).Result;

        public static (IPacket Result, int NextIndex) ReadPacket(ReadOnlySpan<char> bits)
            => (PacketType)ReadByte(bits[3..6]) switch
            {
                PacketType.Literal => ReadLiteral(bits),
                var other => ReadOperator(bits, other),
            };

        public static (Literal, int) ReadLiteral(ReadOnlySpan<char> bits)
        {
            var version = ReadByte(bits[0..3]);
            var digits = new List<byte>();
            var hasNextDigit = false;
            var nextIndex = 6;

            do
            {
                hasNextDigit = bits[nextIndex] == '1';
                digits.Add(ReadByte(bits[(nextIndex + 1)..(nextIndex + 5)]));
                nextIndex += 5;
            } while(hasNextDigit);

            var literal = new Literal(version, digits.Aggregate(0UL, (a, d) => checked(a * 16 + d)));

            return (literal, nextIndex);
        }

        public static (Operator, int) ReadOperator(ReadOnlySpan<char> bits, PacketType type)
        {
            var version = ReadByte(bits[0..3]);
            var packetType = ReadByte(bits[3..6]);
            var packets = new IPacket[0];
            var nextIndex = 0;

            if (bits[6] == '1')
            {
                var length = ReadNumber(bits[7..18]);
                packets = new IPacket[length];
                nextIndex = 18;

                for (var i = 0; i < length; ++i)
                {
                    var (p, n) = ReadPacket(bits.Slice(nextIndex));
                    packets[i] = p;
                    nextIndex += n;
                }
            }
            else
            {
                var length = ReadNumber(bits[7..22]);
                var ps = new List<IPacket>();
                nextIndex = 22;
                var endIndex = 22 + length;

                do
                {
                    var (packet, next) = ReadPacket(bits.Slice(nextIndex, endIndex - nextIndex));

                    ps.Add(packet);
                    nextIndex += next;
                } while(nextIndex != endIndex);

                packets = ps.ToArray();
            }

            return (new Operator(version, (PacketType)packetType, packets.ToArray()), nextIndex);
        }

        public static byte ReadByte(ReadOnlySpan<char> bits) => (byte)ReadNumber(bits);

        public static int ReadNumber(ReadOnlySpan<char> bits)
        {
            var result = 0;

            for (var i = 0; i < bits.Length; ++i) result = result * 2 + (bits[i] == '1' ? 1 : 0);

            return result;
        }
    }
}
