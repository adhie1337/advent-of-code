namespace AdventOfCode2021.Days.Day15
{
    using System.Collections;

    public struct OpenSet : IEnumerable<State>
    {
        private State[] _buffer;
        private Dictionary<int, ulong> _gCache;

        private int _offset;
        private int _lastOffset;
        private int _capacity;

        public OpenSet(int initialCapacity) => (this._buffer, this._gCache, this._capacity, this._offset, this._lastOffset) = (new State[initialCapacity], new Dictionary<int, ulong>(initialCapacity), initialCapacity, 0, 0);

        public void Add(State state)
        {
            if (this._gCache.TryGetValue(state.MinimalRepr, out var stored) && stored < state.G) return;

            this._gCache[state.MinimalRepr] = state.G;

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

                if (this._gCache[result.MinimalRepr] < result.G) return TryGetNext(out result);
                else return true;
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

    public readonly struct ClosedSet
    {
        private readonly HashSet<int> _buffer;

        public ClosedSet(int initialCapacity) => this._buffer = new HashSet<int>(initialCapacity);

        public void Add(State state) => this._buffer.Add(state.MinimalRepr);

        public bool Contains(State state) => this._buffer.Contains(state.MinimalRepr);
    }

    public readonly record struct State(int X, int Y, ulong G, int GoalX, int GoalY, byte[,] Map, (int, int)[] Steps)
    {
        public int H => this.GoalX - this.X + this.GoalY - this.Y;

        public ulong F => this.G + (ulong)this.H;

        public bool IsGoal => this.X == this.GoalX && this.Y == this.GoalY;

        public int MinimalRepr => this.Y * this.Map.GetLength(1) + this.X;

        public IEnumerable<State> GetNeighbors()
        {
            if (this.X < this.GoalX) yield return this.GetRightNeighbor();
            if (this.Y < this.GoalY) yield return this.GetNeighborBelow();
            if (this.X > 0) yield return this.GetLeftNeighbor();
            if (this.Y > 0) yield return this.GetNeighborAbove();
        }

        public State GetNeighborBelow() => this with
            {
                Y = this.Y + 1,
                G = this.G + this.Map[this.Y + 1, this.X],
                Steps = this.Steps.Append((this.X, this.Y + 1)).ToArray()
            };

        public State GetRightNeighbor() => this with
            {
                X = this.X + 1,
                G = this.G + this.Map[this.Y, this.X + 1],
                Steps = this.Steps.Append((this.X + 1, this.Y)).ToArray()
            };

        public State GetNeighborAbove() => this with
            {
                Y = this.Y - 1,
                G = this.G + this.Map[this.Y - 1, this.X],
                Steps = this.Steps.Append((this.X, this.Y - 1)).ToArray()
            };

        public State GetLeftNeighbor() => this with
            {
                X = this.X - 1,
                G = this.G + this.Map[this.Y, this.X - 1],
                Steps = this.Steps.Append((this.X - 1, this.Y)).ToArray()
            };
    }
}
