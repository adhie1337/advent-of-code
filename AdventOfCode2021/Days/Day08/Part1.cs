namespace AdventOfCode2021.Days.Day08
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var map = new Dictionary<char, int>()
            {
                { '0', 6 },
                { '1', 2 },
                { '2', 5 },
                { '3', 5 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 3 },
                { '8', 7 },
                { '9', 6 },
            };

            var outputNumbers = input.SelectMany(_ => _.Split('|')[1].Trim().Split(' '))
                .ToArray();

            var recognizedNumbers = outputNumbers.Select(_ => _.Length)
                .Where(_ => _ != 6 && _ != 5);

            return recognizedNumbers.Count();
        }
    }
}
