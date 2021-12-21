namespace AdventOfCode2021.Days.Day21
{
    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => CountMostWins(GameState.Parse(input, 21));

        public static ulong CountMostWins(GameState game)
        {
            var (player1Wins, player2Wins) = game.CountWins();

            return player1Wins > player2Wins ? player1Wins : player2Wins;
        }
    }
}
