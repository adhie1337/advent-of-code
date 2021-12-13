namespace AdventOfCode2021.Days.Day13
{
    using static FoldDirection;

    public readonly record struct Point(int X, int Y)
    {
        public static Point Parse(string line) => Parse(line.Split(',').Select(int.Parse).ToArray());

        public static Point Parse(int[] coordinates) => new Point(coordinates[0], coordinates[1]);

        public Point After(Fold fold)
            => fold.Direction switch
            {
                Up when this.Y > fold.Distance => this with { Y = 2 * fold.Distance - this.Y },
                Left when this.X > fold.Distance => this with { X = 2 * fold.Distance - this.X },
                _ => this
            };
    }

    public enum FoldDirection { Up, Left }

    public readonly record struct Fold(FoldDirection Direction, int Distance)
    {
        public static Fold Parse(string line) => Parse(line.Split('='));

        public static Fold Parse(string[] parts) => new Fold(parts[0].EndsWith("y") ? Up : Left, int.Parse(parts[1]));
    }

    public readonly record struct Sheet(HashSet<Point> Points, IEnumerable<Fold> Folds)
    {
        public static Sheet Parse(string[] input)
            => new Sheet()
            {
                Points = input.TakeWhile(line => !string.IsNullOrWhiteSpace(line))
                    .Select(Point.Parse)
                    .ToHashSet(),
                Folds = input.SkipWhile(line => !string.IsNullOrWhiteSpace(line))
                    .Skip(1)
                    .Select(Fold.Parse)
                    .ToArray()
            };

        public Sheet ApplyFold() => this.Folds.Any() ? this.ApplyFirstFold() : this;

        private Sheet ApplyFirstFold() => new Sheet(this.ApplyFold(this.Folds.First()), this.Folds.Skip(1));

        private HashSet<Point> ApplyFold(Fold fold) => this.Points.Select(point => point.After(fold)).ToHashSet();
    }
}
