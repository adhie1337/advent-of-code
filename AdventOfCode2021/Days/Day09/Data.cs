namespace AdventOfCode2021.Days.Day09
{
    public readonly record struct Point(int X, int Y)
    {
        public IEnumerable<Point> GetNeighbors()
            => new[]
            {
                new Point(X, Y - 1),
                new Point(X, Y + 1),
                new Point(X - 1, Y),
                new Point(X + 1, Y)
            };
    }

    public readonly record struct LowPoint(Point Point, int Height)
    {
        public int RiskLevel => this.Height + 1;
    };

    public readonly record struct Basin(LowPoint LowPoint, Point[] Points)
    {
        public int Size => this.Points.Length;
    }

    public readonly record struct HeightMap(byte[,] Heights)
    {
        public IEnumerable<Point> GetPoints()
        {
            var heights = this.Heights;

            return Enumerable.Range(0, heights.GetLength(0))
                .SelectMany(y => Enumerable.Range(0, heights.GetLength(1))
                    .Select(x => new Point(x, y)));
        }

        public IEnumerable<Basin> GetBasins()
        {
            foreach (var lowPoint in this.GetLowPoints())
            {
                var points = this.GetBasinPoints(new[] { lowPoint.Point }, new List<Point>());

                yield return new Basin(lowPoint, points);
            }
        }

        public Point[] GetBasinPoints(IEnumerable<Point> pointsToVisit, List<Point> includedPoints)
        {
            if (!pointsToVisit.Any()) return includedPoints.ToArray();

            var nextPoint = pointsToVisit.First();

            includedPoints.Add(nextPoint);

            var nextToVisit = pointsToVisit.Skip(1)
                .Concat(nextPoint.GetNeighbors().Where(this.IsValidNot9))
                .Except(includedPoints)
                .ToArray();

            return this.GetBasinPoints(nextToVisit, includedPoints);
        }

        public bool IsValidPoint(Point p)
            => p.Y >= 0 && p.Y < this.Heights.GetLength(0) &&
                p.X >= 0 && p.X < this.Heights.GetLength(1);

        public bool IsValidNot9(Point p)
            => this.IsValidPoint(p) && this.Heights[p.Y, p.X] != 9;

        public IEnumerable<LowPoint> GetLowPoints()
        {
            var heights = this.Heights;

            return this.GetPoints()
                .Where(this.IsLowPoint)
                .Select(p => new LowPoint(p, heights[p.Y, p.X]));
        }

        public bool IsLowPoint(Point p)
        {
            foreach (var neighbor in p.GetNeighbors())
                if (this.IsValidPoint(neighbor) && !this.IsHigherPointThan(neighbor, p))
                    return false;

            return true;
        }

        public bool IsHigherPointThan(Point a, Point b) => this.Heights[a.Y, a.X] > this.Heights[b.Y, b.X];

        public static HeightMap Parse(string[] lines)
            => Parse(lines.Select(_ => _.ToArray().Select(_ => byte.Parse("" + _)).ToArray()).ToArray());

        public static HeightMap Parse(byte[][] heights)
        {
            var r = new byte[heights.Length, heights[0].Length];

            for (var i = 0; i < heights.Length; ++i)
            {
                for (var j = 0; j < heights[0].Length; ++j)
                {
                    r[i, j] = heights[i][j];
                }
            }

            return new HeightMap(r);
        }
    }
}
