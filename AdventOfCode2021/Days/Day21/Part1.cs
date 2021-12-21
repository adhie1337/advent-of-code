namespace AdventOfCode2021.Days.Day21
{
    public class Part1 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => Simulate(GameState.Parse(input, 1000), new DeterministicDie(100));

        public static ulong Simulate(GameState game, DeterministicDie die) => game.ResultAfterNextTurn(ref die) ?? Simulate(game, die);
    }
}
