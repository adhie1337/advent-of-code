namespace AdventOfCode2021.Days.Day19
{
    using System.Text.RegularExpressions;

    public readonly record struct Position(int X, int Y, int Z)
    {
        public int NonZeroCoords => (this.X == 0 ? 0 : 1) + (this.Y == 0 ? 0 : 1) + (this.Z == 0 ? 0 : 1);

        public static readonly Position Center = new Position();

        public static Position Parse(string line) => Create(line.Split(',').Select(int.Parse).ToArray());

        public static Position Create(int[] coordinates) => new Position(coordinates[0], coordinates[1], coordinates[2]);

        public double Distance(Position other)
            => Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2) + Math.Pow(this.Z - other.Z, 2));

        public int ManhattanDistance(Position other)
            => Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y) + Math.Abs(this.Z - other.Z);

        public static Position operator +(Position left, Position right)
            => new Position(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static Position operator -(Position left, Position right)
            => new Position(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }

    public readonly record struct Beacon(Position Position, (double Distance, Beacon Beacon)[]? DistanceMap = null)
    {
        public IEnumerable<double> GetDistances() => this.DistanceMap!.Select(d => d.Distance);

        public static Beacon Parse(string line) => new Beacon(Position.Parse(line));

        public static Beacon At(int x, int y, int z) => new Beacon(new Position(x, y, z));

        public bool Equals(Beacon other) => this.Position.Equals(other.Position);

        public override int GetHashCode() => this.Position.GetHashCode();
    }

    public readonly record struct Scanner(int Id, Beacon[] VisibleBeacons, Position? Position = default)
    {
        public static readonly Regex TitlePattern = new Regex(@"--- scanner (\d+) ---");

        public static Scanner Parse(IEnumerable<string> lines)
            => new Scanner()
            {
                Id = int.Parse(TitlePattern.Match(lines.First()).Groups[1].ValueSpan),
                VisibleBeacons = lines.Skip(1).Select(Beacon.Parse).ToArray()
            };

        public Scanner WithDistances()
        {
            if (this.VisibleBeacons[0].DistanceMap != null) return this;

            var beacons = this.VisibleBeacons;

            var groups = beacons.Select(beacon => beacon with
                {
                    DistanceMap = beacons.Where(other => beacon.Position != other.Position)
                        .Select(other => (beacon.Position.Distance(other.Position), other))
                        .ToArray()
                });

            return this with { VisibleBeacons = groups.ToArray() };
        }
    }

    public static class Scanners
    {
        public static Scanner[] TranslateToZero(Scanner[] scanners, int limit)
        {
            var withDistances = scanners.Select(s => s.WithDistances()).ToArray();

            var newScanners = new Dictionary<int, Scanner>()
            {
                { withDistances[0].Id, new Scanner(withDistances[0].Id, withDistances[0].VisibleBeacons, Position.Center) },
            };

            while (newScanners.Count != scanners.Length)
            {
                foreach (var scanner in withDistances.Where(scanner => !newScanners.ContainsKey(scanner.Id)))
                {
                    var matches =
                        from storedScanner in newScanners.Values
                        from storedBeacon in storedScanner.VisibleBeacons
                        from beacon in scanner.VisibleBeacons
                        where storedBeacon.GetDistances().Intersect(beacon.GetDistances()).Count() >= limit - 1
                        select (storedBeacon, beacon);

                    foreach (var (storedBeacon, beacon) in matches)
                    {
                        var getDeltas =
                            from stored in storedBeacon.DistanceMap!
                            join dist in beacon.DistanceMap! on stored.Distance equals dist.Distance
                            let d = storedBeacon.Position - stored.Beacon.Position
                            let otherD = beacon.Position - dist.Beacon.Position
                            let transformer = GetTransformer(d, otherD)
                            where transformer is Func<Position, Position> t
                            let nonZeroCoords = d.NonZeroCoords + otherD.NonZeroCoords
                            orderby nonZeroCoords
                            select (d, otherD, transformer);

                        if (!getDeltas.Any()) continue;

                        var (storedDelta, otherDelta, transform) = getDeltas.First();
                        var newScannerPosition = storedBeacon.Position - transform(beacon.Position);
                        var newBeacons = scanner.VisibleBeacons
                            .Select(b => new Beacon(newScannerPosition + transform(b.Position)))
                            .ToArray();

                        newScanners[scanner.Id] = new Scanner(scanner.Id, newBeacons, newScannerPosition).WithDistances();

                        break;
                    }
                }
            }

            return newScanners.Values.ToArray();
        }

        public static Func<Position, Position>? GetTransformer(Position delta, Position otherDelta)
        {
            var x = delta.X == otherDelta.X ? (Func<Position, int>?)KeepX :
                delta.X == -otherDelta.X ? NegateX :
                delta.X == otherDelta.Y ? KeepY :
                delta.X == -otherDelta.Y ? NegateY :
                delta.X == otherDelta.Z ? KeepZ :
                delta.X == -otherDelta.Z ? NegateZ :
                null;
            var y = delta.Y == otherDelta.X ? (Func<Position, int>?)KeepX :
                delta.Y == -otherDelta.X ? NegateX :
                delta.Y == otherDelta.Y ? KeepY :
                delta.Y == -otherDelta.Y ? NegateY :
                delta.Y == otherDelta.Z ? KeepZ :
                delta.Y == -otherDelta.Z ? NegateZ :
                null;
            var z = delta.Z == otherDelta.X ? (Func<Position, int>?)KeepX :
                delta.Z == -otherDelta.X ? NegateX :
                delta.Z == otherDelta.Y ? KeepY :
                delta.Z == -otherDelta.Y ? NegateY :
                delta.Z == otherDelta.Z ? KeepZ :
                delta.Z == -otherDelta.Z ? NegateZ :
                null;

            return x != null && y != null && z != null ? p => new Position(x.Invoke(p), y.Invoke(p), z.Invoke(p)) : null;
        }

        public static int KeepX(Position p) => p.X;
        public static int NegateX(Position p) => -p.X;
        public static int KeepY(Position p) => p.Y;
        public static int NegateY(Position p) => -p.Y;
        public static int KeepZ(Position p) => p.Z;
        public static int NegateZ(Position p) => -p.Z;

        public static Scanner[] Parse(IEnumerable<string> input)
        {
            var scannerCount = input.Count(string.IsNullOrEmpty) + 1;
            var result = new Scanner[scannerCount];
            var rest = input;

            for (var i = 0; i < scannerCount; ++i)
            {
                var act = rest.TakeWhile(line => !string.IsNullOrEmpty(line));
                result[i] = Scanner.Parse(act);
                rest = rest.SkipWhile(line => !string.IsNullOrEmpty(line)).Skip(1);
            }

            return result;
        }
    }
}
