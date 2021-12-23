namespace AdventOfCode2021.Days.Day22
{
    using System.Text.RegularExpressions;

    public enum State : byte { On = 1, Off = 0 }

    public readonly record struct Command(State State, Range3D Range)
    {
        public static readonly Regex CommandPattern = new Regex(@"(on|off) x=(-?\d+)..(-?\d+),y=(-?\d+)..(-?\d+),z=(-?\d+)..(-?\d+)");

        public static List<Range3D> SplitCommands(IEnumerable<Command> commands)
        {
            var result = new List<Range3D>();

            foreach (var command in commands)
            {
                var c = command.Range;

                for (var i = 0; i < result.Count; ++i)
                {
                    var r = result[i];

                    if (r == c)
                    {
                        result.RemoveAt(i--);
                    }
                    else if (r.OverlapsWith(c))
                    {
                        var (_, parts) = r.SplitOut(c);

                        result.RemoveAt(i);
                        result.InsertRange(i, parts);
                        i += parts.Count - 1;
                    }
                }

                if (command.State == State.On) result.Add(c);
            }

            return result;
        }

        public static Command Parse(string line)
            => Create(CommandPattern.Match(line).Groups.OfType<Group>().Skip(1).Select(g => g.Value).ToArray());

        private static Command Create(string[] parts)
            => new Command()
            {
                State = parts[0] == "on" ? State.On : State.Off,
                Range = new Range3D()
                {
                    X = ParseRange(parts[1], parts[2]),
                    Y = ParseRange(parts[3], parts[4]),
                    Z = ParseRange(parts[5], parts[6]),
                },
            };

        private static Range ParseRange(string start, string end) => CreateRange(int.Parse(start), int.Parse(end));

        private static Range CreateRange(int start, int end) => new Range(Math.Min(start, end), Math.Max(start, end));
    }

    public readonly record struct Range(int Start, int End)
    {
        public int Size => this.End - this.Start;

        public bool OverlapsWith(Range other)
            => other.Start >= this.Start && other.Start <= this.End
                || other.End >= this.Start && other.End <= this.End
                || other.Start < this.Start && other.End > this.End;
    }

    public readonly record struct Range3D(Range X, Range Y, Range Z)
    {
        public int Width => this.X.Size;

        public int Height => this.Y.Size;

        public int Depth => this.Z.Size;

        public ulong Count => (ulong)(this.Width + 1) * (ulong)(this.Height + 1) * (ulong)(this.Depth + 1);

        public bool OverlapsWith(Range3D other)
            => this.X.OverlapsWith(other.X) && this.Y.OverlapsWith(other.Y) && this.Z.OverlapsWith(other.Z);

        public (Range3D CommonPart, List<Range3D> Parts) SplitOut(Range3D other)
        {
            var parts = new List<Range3D>();

            var self = this;

            if (self.X.Start < other.X.Start)
            {
                parts.Add(self with { X = new Range(self.X.Start, other.X.Start - 1) });
                self = self with { X = new Range(other.X.Start, self.X.End) };
            }
            if (other.X.End < self.X.End)
            {
                parts.Add(self with { X = new Range(other.X.End + 1, self.X.End) });
                self = self with { X = new Range(self.X.Start, other.X.End) };
            }

            if (self.Y.Start < other.Y.Start)
            {
                parts.Add(self with { Y = new Range(self.Y.Start, other.Y.Start - 1) } );
                self = self with { Y = new Range(other.Y.Start, self.Y.End) };
            }
            if (other.Y.End < self.Y.End)
            {
                parts.Add(self with { Y = new Range(other.Y.End + 1, self.Y.End) });
                self = self with { Y = new Range(self.Y.Start, other.Y.End) };
            }

            if (self.Z.Start < other.Z.Start)
            {
                parts.Add(self with { Z = new Range(self.Z.Start, other.Z.Start - 1) });
                self = self with { Z = new Range(other.Z.Start, self.Z.End) };
            }
            if (other.Z.End < self.Z.End)
            {
                parts.Add(self with { Z = new Range(other.Z.End + 1, self.Z.End) });
                self = self with { Z = new Range(self.Z.Start, other.Z.End) };
            }

            return (self, parts);
        }
    }

    public static class Factory
    {
        public static Range Range(int start, int end) => new Range(start, end);

        public static Range3D Range3D(Range x, Range y, Range z) => new Range3D(x, y, z);

        public static Command Command(State state, Range3D range) => new Command(state, range);
    }
}
