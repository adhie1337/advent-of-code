namespace AdventOfCode2021.Days.Day08
{
    public readonly record struct Line(string[] DigitCodes, string[] OutputDigits)
    {
        public int OutputValue
        {
            get
            {
                var digitMap = this.CreateDigitMap();

                return this.OutputDigits.Aggregate(0, (a, k) => a * 10 + digitMap[Key(k.ToArray())]);
            }
        }

        public Dictionary<string, int> CreateDigitMap()
        {
            var linesOf1 = this.DigitCodes.Single(_ => _.Length == 2);
            var linesOf4 = this.DigitCodes.Single(_ => _.Length == 4);
            var linesOf7 = this.DigitCodes.Single(_ => _.Length == 3);
            var linesOf8 = this.DigitCodes.Single(_ => _.Length == 7);

            var top = linesOf7.Except(linesOf1).Single();
            var bottomRight = this.DigitCodes
                .Where(_ => _.Length == 6)
                .Aggregate(linesOf1.AsQueryable(), (a, b) => a.Intersect(b))
                .Single();
            var topRight = linesOf1.Except(new[] { bottomRight }).Single();
            var middle = this.DigitCodes
                .Where(_ => _.Length == 5)
                .Aggregate(linesOf4.AsQueryable(), (a, b) => a.Intersect(b))
                .Single();
            var topLeft = linesOf4.Except(linesOf1 + middle).Single();
            var bottom = this.DigitCodes
                .Where(_ => _.Length == 6)
                .OfType<IEnumerable<char>>()
                .Aggregate((a, b) => a.Intersect(b))
                .Except("" + top + topLeft + bottomRight)
                .Single();
            var bottomLeft = linesOf8
                .Except("" + top + topRight + topLeft + middle + bottomRight + bottom)
                .Single();

            return new Dictionary<string, int>()
            {
                { Key(top, topLeft, topRight, bottomLeft, bottomRight, bottom), 0 },
                { Key(topRight, bottomRight), 1 },
                { Key(top, topRight, middle, bottomLeft, bottom), 2 },
                { Key(top, topRight, middle, bottomRight, bottom), 3 },
                { Key(topLeft, topRight, middle, bottomRight), 4 },
                { Key(top, topLeft, middle, bottomRight, bottom), 5 },
                { Key(top, topLeft, middle, bottomLeft, bottomRight, bottom), 6 },
                { Key(top, topRight, bottomRight), 7 },
                { Key(top, topLeft, topRight, middle, bottomLeft, bottomRight, bottom), 8 },
                { Key(top, topLeft, topRight, middle, bottomRight, bottom), 9 },
            };
        }

        public static string Key(params char[] args) => new String(args.OrderBy(_ => _).ToArray());

        public static Line Parse(string line) => Create(Split(line));

        public static string[][] Split(string line) => line.Split('|').Select(_ => _.Trim().Split(' ')).ToArray();

        public static Line Create(string[][] parts) => new Line(parts[0], parts[1]);
    }
}
