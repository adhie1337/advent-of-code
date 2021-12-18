namespace AdventOfCode2021.Days.Day17
{
    using System.Text.RegularExpressions;

    public readonly record struct Point(int X, int Y)
    {
        public static readonly Point Origin = new Point();

        public Point Move(Velocity velocity) => new Point(this.X + velocity.X, this.Y +  velocity.Y);
    }

    public readonly record struct Velocity(int X, int Y)
    {
        public Velocity Next() => new Velocity(this.X + (this.X < 0 ? 1 : this.X > 0 ? -1 : 0), this.Y - 1);
    }

    public readonly record struct TargetArea(int LeftX, int RightX, int TopY, int BottomY)
    {
        public static readonly Regex Pattern = new Regex(@"target area: x=(-?\d+)..(-?\d+), y=(-?\d+)..(-?\d+)");

        public bool IsInTarget(Point p)
            => p.X >= this.LeftX && p.X <= this.RightX && p.Y <= this.TopY && p.Y >= this.BottomY;

        public static TargetArea Parse(string input)
            => Create(Pattern.Match(input).Groups.OfType<Group>().Skip(1).Select(g => int.Parse(g.ValueSpan)).ToArray());

        public static TargetArea Create(int[] coords)
            => new TargetArea()
            {
                LeftX = Math.Min(coords[0], coords[1]),
                RightX = Math.Max(coords[0], coords[1]),
                TopY = Math.Max(coords[2], coords[3]),
                BottomY = Math.Min(coords[2], coords[3]),
            };

        public HashSet<Velocity> GetPossibleAims()
        {
            var possibleXs = new HashSet<int>();

            for (var i = this.RightX; i > 0; --i)
            {
                if (i >= this.LeftX) possibleXs.Add(i);

                var step = 0;

                for (var j = i; j >= 0; --j)
                {
                    if (step >= this.LeftX && step <= this.RightX) possibleXs.Add(i);
                    step += j;
                }
            }

            var possibleAims = new HashSet<Velocity>();

            var min = Math.Min(-Math.Abs(this.BottomY), -Math.Abs(this.TopY));
            var max = Math.Max(Math.Abs(this.BottomY), Math.Abs(this.TopY));

            foreach (var x in possibleXs)
            {
                for (var i = min; i <= max; ++i)
                {
                    var velocity = new Velocity(x, i);
                    if (Simulate(Point.Origin, velocity).Any(this.IsInTarget))
                        possibleAims.Add(velocity);
                }
            }

            return possibleAims;
        }

        public IEnumerable<Point> Simulate(Point origin, Velocity velocity)
        {
            var point = origin;
            var v = velocity;

            while (CanBeReached(point, v))
            {
                (point, v) = (point.Move(v), v.Next());

                yield return point;
            }
        }

        public bool CanBeReached(Point point, Velocity velocity)
            => (this.BottomY < point.Y || velocity.Y > 0) &&
                (velocity.X < 0 && this.LeftX < point.X || // Still moving tovards target (to the left)
                velocity.X > 0 && this.RightX > point.X || // Still moving tovards target (to the right)
                velocity.X == 0); // Point is in line with target area
    }
}
