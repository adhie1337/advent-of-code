namespace AdventOfCode2021.Days.Day21
{
    public unsafe ref struct GameState
    {
        public const int SpaceCount = 10;

        private fixed byte _position[2];

        private fixed ushort _score[2];

        private ushort _winScore;

        public bool IsFinished => this._score[0] >= this._winScore || this._score[1] >= this._winScore;

        public GameState(byte player1Position, byte player2Position, ushort winScore)
            => (this._position[0], this._position[1], this._winScore) = (player1Position, player2Position, winScore);

        public static GameState Parse(string[] input, ushort winScore)
            => new GameState(byte.Parse(input[0][28..]), byte.Parse(input[1][28..]), winScore);

        public unsafe ulong? ResultAfterNextTurn(ref DeterministicDie die)
        {
            var player = die.RollCount % 2;
            this._position[player] = (byte)((this._position[player] + die.Roll() + die.Roll() + die.Roll() - 1) % SpaceCount + 1);
            this._score[player] += this._position[player];

            return !this.IsFinished ? null : Math.Min(this._score[0], this._score[1]) * die.RollCount;
        }
    }

    public ref struct DeterministicDie
    {
        private ulong _rollCount = 0;

        private byte _sides;

        public ulong RollCount => this._rollCount;

        public DeterministicDie(byte sides) => this._sides = sides;

        public unsafe byte Roll() => (byte)((++this._rollCount % this._sides));
    }
}
