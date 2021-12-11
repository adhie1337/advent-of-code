namespace AdventOfCode2021.Days.Day10
{
    public class Part1 : Solution<int>
    {
        private static readonly Dictionary<char, int> Scores = new Dictionary<char, int>()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        private static readonly Dictionary<char, char> CloseMap = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' },
        };

        public override int Apply(string[] input) => CalculateSyntaxErrorScore(input);

        public static int CalculateSyntaxErrorScore(IEnumerable<string> lines)
            => lines.Sum(_ => CalculateSyntaxErrorScore(_).GetValueOrDefault());

        public static int? CalculateSyntaxErrorScore(string line)
        {
            var stack = new Stack<char>();

            for (var i = 0; i < line.Length; ++i)
            {
                if (CloseMap.TryGetValue(line[i], out var closingChar)) stack.Push(closingChar);
                else if (stack.Peek() == line[i]) stack.Pop();
                else return Scores[line[i]];
            }

            return default;
        }
    }
}
