namespace AdventOfCode2021.Days.Day21
{
    public unsafe ref struct GameState
    {
        public const int SpaceCount = 10;

        private fixed byte _position[2];

        private fixed ushort _score[2];

        private ushort _winScore;

        public bool IsFinished => this.PlayerWon(0) || this.PlayerWon(1);

        public bool PlayerWon(int player) => this._score[player] >= this._winScore;

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

        public unsafe (ulong, ulong) CountWins(bool player1Turn = true)
        {
            if (this.PlayerWon(0)) return (1, 0);
            if (this.PlayerWon(1)) return (0, 1);

            var playerWins = stackalloc [] { 0ul, 0ul };
            var next = new GameState();
            next._winScore = this._winScore;

            var possibilities = stackalloc ulong[]
            {
                1, // result: 3, combinations: 1 & 1 & 1 (1 possible way)
                3, // result: 4, combinations: 1 & 1 & 2 (3 possible ways)
                6, // result: 5, combinations: 1 & 2 & 2 (3 possible ways) + 1 & 1 & 3 (3 possible ways)
                7, // result: 6, combinations: 1 & 2 & 3 (6 possible ways) + 2 & 2 & 2 (1 possible way)
                6, // result: 7, combinations: 2 & 2 & 3 (3 possible ways) + 1 & 3 & 3 (3 possible ways)
                3, // result: 8, combinations: 2 & 3 & 3 (3 possible ways)
                1, // result: 9, combinations: 3 & 3 & 3 (1 possible way)
            };

            for (var i = 0; i < 7; ++i)
            {
                var dieResult = i + 3;

                if (player1Turn)
                {
                    next._position[0] = (byte)((this._position[0] + dieResult - 1) % SpaceCount + 1);
                    next._score[0] = (ushort)(this._score[0] + next._position[0]);
                    next._position[1] = this._position[1];
                    next._score[1] = this._score[1];
                }
                else
                {
                    next._position[0] = this._position[0];
                    next._score[0] = this._score[0];
                    next._position[1] = (byte)((this._position[1] + dieResult - 1) % SpaceCount + 1);
                    next._score[1] = (ushort)(this._score[1] + next._position[1]);
                }

                var (player1Win, player2Win) = next.CountWins(!player1Turn);

                var possibleCombinations = possibilities[i];
                playerWins[0] += player1Win * possibleCombinations;
                playerWins[1] += player2Win * possibleCombinations;
            }

            return (playerWins[0], playerWins[1]);
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
