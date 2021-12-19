namespace AdventOfCode2021.Tests.Days.Day14
{
    using System.Collections.Generic;

    using AdventOfCode2021.Days.Day14;

    public static class Example
    {
        public static readonly PolimerizationState State = new PolimerizationState()
        {
            Template = "NNCB",
            Rules = new Dictionary<(char, char), char>()
            {
                { ('C', 'H'), 'B' },
                { ('H', 'H'), 'N' },
                { ('C', 'B'), 'H' },
                { ('N', 'H'), 'C' },
                { ('H', 'B'), 'C' },
                { ('H', 'C'), 'B' },
                { ('H', 'N'), 'C' },
                { ('N', 'N'), 'C' },
                { ('B', 'H'), 'H' },
                { ('N', 'C'), 'B' },
                { ('N', 'B'), 'B' },
                { ('B', 'N'), 'B' },
                { ('B', 'B'), 'N' },
                { ('B', 'C'), 'B' },
                { ('C', 'C'), 'N' },
                { ('C', 'N'), 'C' },
            }
        };
    }
}
