namespace AdventOfCode2021.Days.Day05
{
    public readonly record struct Point(int X, int Y)
    {
        public static Point Parse(string line) => Parse(line.Split(","));

        public static Point Parse(string[] coords) => Parse(coords.Select(int.Parse).ToArray());

        public static Point Parse(int[] coords) => new Point(coords[0], coords[1]);
    }

    public readonly record struct Line(Point Start, Point End)
    {
        public int HorizontalDistance => this.End.X - this.Start.X;
        
        public int VerticalDistance => this.End.Y - this.Start.Y;

        public bool IsHorizontal => this.VerticalDistance == 0;

        public bool IsVertical => this.HorizontalDistance == 0;

        public int LeftX => Math.Min(this.Start.X, this.End.X);

        public int RightX => Math.Max(this.Start.X, this.End.X);

        public int TopY => Math.Min(this.Start.Y, this.End.Y);

        public int BottomY => Math.Max(this.Start.Y, this.End.Y);

        public static Line Parse(string line) => Parse(line.Split(" -> "));

        public static Line Parse(string[] points) => new Line(Point.Parse(points[0]), Point.Parse(points[1]));
    }
}