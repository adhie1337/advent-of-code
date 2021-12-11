namespace AdventOfCode2021.Days.Day08
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CountRecognizedNumbers(input.SelectMany(_ => _.Split('|')[1].Trim().Split(' ')));

        public static int CountRecognizedNumbers(IEnumerable<string> numbers)
            => numbers.Select(_ => _.Length).Where(_ => _ != 6 && _ != 5).Count();
    }
}
