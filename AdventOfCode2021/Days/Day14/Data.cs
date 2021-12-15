namespace AdventOfCode2021.Days.Day14
{
    public readonly record struct PolimerizationState(string Template, Dictionary<(char, char), char> Rules)
    {
        public static PolimerizationState Parse(string[] input) => new PolimerizationState()
        {
            Template = input[0],
            Rules = input.Skip(2)
                .Select(line => line.Split(" -> "))
                .ToDictionary(parts => (parts[0][0], parts[0][1]), parts => parts[1][0])
        };
    }
}
