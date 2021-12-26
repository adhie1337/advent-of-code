namespace AdventOfCode2021.Days.Day23
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public struct OpenSet : IEnumerable<State>
    {
        private State[] _buffer;

        private int _offset;
        private int _lastOffset;
        private int _capacity;

        public OpenSet(int initialCapacity) => (this._buffer, this._capacity, this._offset, this._lastOffset) = (new State[initialCapacity], initialCapacity, 0, 0);

        public void Add(State state)
        {

            if (this._lastOffset == this._capacity)
            {
                if (this._offset == 0) this.Resize();
                else this.Compact();
            }

            var (lower, upper) = (this._offset, this._lastOffset);

            while (lower < upper)
            {
                var between = (int)Math.Floor(((double)lower + upper) / 2);

                if (this._buffer[between].F > state.F) upper = between;
                else if (lower < between) lower = between;
                else lower = between + 1;
            }

            if (lower < this._lastOffset) Array.Copy(this._buffer, lower, this._buffer, lower + 1, this._lastOffset - lower);

            this._buffer[lower] = state;
            this._lastOffset++;
        }

        public bool TryGetNext(out State result)
        {
            if (this._offset < this._lastOffset)
            {
                result = this._buffer[this._offset++];

                if (this._offset == this._lastOffset) this._offset = this._lastOffset = 0;

                return true;
            }

            result = default;
            return false;
        }

        private void Compact()
        {
            Array.Copy(this._buffer, this._offset, this._buffer, 0, this._lastOffset - this._offset);
            this._lastOffset -= this._offset;
            this._offset = 0;
        }

        private void Resize()
        {
            var newBuffer = new State[this._capacity * 2];
            Array.Copy(this._buffer, this._offset, newBuffer, 0, this._lastOffset - this._offset);
            this._buffer = newBuffer;
            this._lastOffset -= this._offset;
            this._offset = 0;
            this._capacity *= 2;
        }

        public IEnumerator<State> GetEnumerator() => this._buffer[this._offset..this._lastOffset].OfType<State>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public readonly struct ClosedSet : IEnumerable<BigInteger>
    {
        private readonly HashSet<BigInteger> _buffer;

        public int Length => this._buffer.Count;

        public ClosedSet(int initialCapacity) => this._buffer = new HashSet<BigInteger>(initialCapacity);

        public void Add(State state) => this._buffer.Add(state.MinimalRepr);

        public bool Contains(State state) => this._buffer.Contains(state.MinimalRepr);

        public IEnumerator<BigInteger> GetEnumerator() => this._buffer.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this._buffer.GetEnumerator();
    }

    public enum AmphipodState : byte
    {
        WaitingToMove = 0,
        InHallway = 1,
        InRoom = 2
    }

    public readonly record struct Amphipod(int X, int Y, byte Type, AmphipodState State)
    {
        public int E => (int)Math.Pow(10, this.Type - 1);

        public int TargetX => 1 + this.Type * 2;

        public int XDelta => Math.Abs(this.TargetX - this.X);

        public long GetH()
            => this.State == AmphipodState.InRoom ? 0
            : this.State == AmphipodState.InHallway ? (long)(this.E * this.XDelta)
            : (long)(this.E * (this.XDelta + this.Y));
    }

    public readonly record struct State(byte[,] Map, Amphipod[] Amphipods, int Energy)
    {
        public BigInteger MinimalRepr
            => this.Amphipods.OrderBy(a => (a.Type, (byte)a.State, a.X, a.Y))
                .Aggregate(BigInteger.Zero, (s, a) => s * 140 + (ulong)(a.X * 10 + a.Y));

        public ulong G => (ulong)this.Energy;

        public ulong H
        {
            get
            {
                var result = 0ul;

                foreach (var a in this.Amphipods.Where(a => a.State != AmphipodState.InRoom))
                {
                    result += (ulong)(a.E * (a.XDelta + a.Y));
                }

                return result;
            }
        }

        public ulong F => this.H + this.G;

        public bool IsGoal => this.Amphipods.All(a => a.State == AmphipodState.InRoom);

        public string Print()
        {
            var result = new StringBuilder();

            for (var y = 0; y < this.Map.GetLength(1); ++y)
            {
                for (var x = 0; x < this.Map.GetLength(0); ++x)
                {
                    result.Append(this.Map[x, y] switch
                        {
                            (byte)255 => '#',
                            (byte)0   => '.',
                            var c     => (char)('A' + c - 1),
                        });
                }

                result.AppendLine();
            }
            result.AppendLine($"F = { this.F } ({ this.G } + { this.H }), IsGoal { this.IsGoal }");
            result.AppendLine();

            return result.ToString();
        }

        public IEnumerable<State> GetNeighbors()
        {
            var result = new List<State>();

            foreach (var a in this.Amphipods)
            {
                foreach (var (n, e) in this.GetNeighbors(a))
                {
                    var map = new byte[this.Map.GetLength(0), this.Map.GetLength(1)];
                    Array.Copy(this.Map, map, this.Map.Length);

                    (map[a.X, a.Y], map[n.X, n.Y]) = (0, a.Type);

                    result.Add(new State()
                    {
                        Map = map,
                        Amphipods = this.Amphipods.Except(new[] { a }).Append(n).ToArray(),
                        Energy = this.Energy + e,
                    });
                }
            }

            return result;
        }

        public bool CanMoveTo(int x, int y) => this.Map[x, y] == 0;

        public bool IsInFrontOfDoor(int x) => x > 2 && x < 10 && x % 2 == 1;

        public List<(Amphipod, int)> GetNeighbors(Amphipod a)
        {
            var result = new List<(Amphipod, int)>(10);

            if (a.State == AmphipodState.WaitingToMove)
            {
                var canComeOut = true;

                for (var y = 2; y < a.Y && canComeOut; ++y) canComeOut &= this.CanMoveTo(a.X, y);

                if (canComeOut)
                {
                    var leftStop = !this.CanMoveTo(a.X, 1);
                    var rightStop = leftStop;
                    var dy = a.Y - 1;

                    for (var dx = 1; dx < 10 && (!leftStop || !rightStop); ++dx)
                    {
                        if (!leftStop)
                        {
                            var leftX = a.X - dx;
                            if (!this.CanMoveTo(leftX, 1)) leftStop = true;
                            else if (!this.IsInFrontOfDoor(leftX))
                                result.Add((a with { X = leftX, Y = 1, State = AmphipodState.InHallway }, (dx + dy) * a.E));
                        }
                        if (!rightStop)
                        {
                            var rightX = a.X + dx;
                            if (!this.CanMoveTo(rightX, 1)) rightStop = true;
                            else if (!this.IsInFrontOfDoor(rightX))
                                result.Add((a with { X = rightX, Y = 1, State = AmphipodState.InHallway }, (dx + dy) * a.E));
                        }
                    }
                }
            }
            else if (a.State == AmphipodState.InHallway)
            {
                var canGoDownY = (int?)0;

                for (var y = 2; y < this.Map.GetLength(1) - 1 && canGoDownY.HasValue; ++y)
                {
                    if (this.CanMoveTo(a.TargetX, y)) canGoDownY = y - 1;
                    else if (this.Map[a.TargetX, y] != a.Type) canGoDownY = null;
                }

                if (canGoDownY is int dy)
                {
                    var (success, dx) = (true, a.XDelta);

                    foreach (var i in Enumerable.Range(1, dx))
                        success &= this.CanMoveTo(a.X < a.TargetX ? a.X + i : a.TargetX + i - 1, 1);

                    if (success) result.Add((a with { X = a.TargetX, Y = 1 + dy, State = AmphipodState.InRoom }, a.E * (dy + dx)));
                }
            }

            return result;
        }

        public static State Parse(string[] input)
        {
            var map = new byte[input[0].Length, input.Length];
            var amphipods = new List<Amphipod>();

            for (var y = 0; y < input.Length; ++y)
            {
                var line = input[y];

                for (var x = 0; x < line.Length; ++x)
                {
                    byte b = line[x] switch
                    {
                        'A' => 1,
                        'B' => 2,
                        'C' => 3,
                        'D' => 4,
                        '#' => 255,
                        _   => 0,
                    };

                    map[x, y] = b;

                    if (b > 0 && b < 255)
                    {
                        amphipods.Add(new Amphipod()
                        {
                            X = x,
                            Y = y,
                            Type = b,
                            State = x == 1 + b * 2 && y > 1 && Enumerable.Range(y, input.Length - 2 - y).All(i => input[y][i] == b) ? AmphipodState.InRoom : AmphipodState.WaitingToMove
                        });
                    }
                }
            }

            return new State()
            {
                Map = map,
                Amphipods = amphipods.ToArray(),
                Energy = 0,
            };
        }
    }
}
