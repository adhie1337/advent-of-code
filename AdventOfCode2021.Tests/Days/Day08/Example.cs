namespace AdventOfCode2021.Tests.Days.Day08
{
    using AdventOfCode2021.Days.Day08;

    public static class Example
    {
        public static readonly string[] Input = new[]
        {
            "fdgacbe", "cefdb", "cefbgd", "gcbe",
            "fcgedb", "cgb", "dgebacf", "gc", "cg",
            "cg", "fdcagb", "cbg",
            "efabcd", "cedba", "gadfec", "cb",
            "gecf", "egdcabf", "bgf", "bfgea",
            "gebdcfa", "ecba", "ca", "fadegcb",
            "cefg", "dcbef", "fcge", "gbcadfe",
            "ed", "bcgafe", "cdgba", "cbgef",
            "gbdfcae", "bgc", "cg", "cgb",
            "fgae", "cfgab", "fg", "bagce"
        };

        public static readonly Line[] Lines = new[]
        {
            new Line()
            {
                DigitCodes = new[] { "be", "cfbegad", "cbdgef", "fgaecd", "cgeb", "fdcge", "agebfd", "fecdb", "fabcd", "edb" },
                OutputDigits = new[] { "fdgacbe", "cefdb", "cefbgd", "gcbe" }
            },
            new Line()
            {
                DigitCodes = new[] { "edbfga", "begcd", "cbg", "gc", "gcadebf", "fbgde", "acbgfd", "abcde", "gfcbed", "gfec"  },
                OutputDigits = new[] { "fcgedb", "cgb", "dgebacf", "gc"  }
            },
            new Line()
            {
                DigitCodes = new[] { "fgaebd", "cg", "bdaec", "gdafb", "agbcfd", "gdcbef", "bgcad", "gfac", "gcb", "cdgabef"  },
                OutputDigits = new[] { "cg", "cg", "fdcagb", "cbg"  }
            },
            new Line()
            {
                DigitCodes = new[] { "fbegcd", "cbd", "adcefb", "dageb", "afcb", "bc", "aefdc", "ecdab", "fgdeca", "fcdbega"  },
                OutputDigits = new[] { "efabcd", "cedba", "gadfec", "cb"  }
            },
            new Line()
            {
                DigitCodes = new[] { "aecbfdg", "fbg", "gf", "bafeg", "dbefa", "fcge", "gcbea", "fcaegb", "dgceab", "fcbdga"  },
                OutputDigits = new[] { "gecf", "egdcabf", "bgf", "bfgea"  }
            },
            new Line()
            {
                DigitCodes = new[] { "fgeab", "ca", "afcebg", "bdacfeg", "cfaedg", "gcfdb", "baec", "bfadeg", "bafgc", "acf"  },
                OutputDigits = new[] { "gebdcfa", "ecba", "ca", "fadegcb"  }
            },
            new Line()
            {
                DigitCodes = new[] { "dbcfg", "fgd", "bdegcaf", "fgec", "aegbdf", "ecdfab", "fbedc", "dacgb", "gdcebf", "gf"  },
                OutputDigits = new[] { "cefg", "dcbef", "fcge", "gbcadfe"  }
            },
            new Line()
            {
                DigitCodes = new[] { "bdfegc", "cbegaf", "gecbf", "dfcage", "bdacg", "ed", "bedf", "ced", "adcbefg", "gebcd"  },
                OutputDigits = new[] { "ed", "bcgafe", "cdgba", "cbgef"  }
            },
            new Line()
            {
                DigitCodes = new[] { "egadfb", "cdbfeg", "cegd", "fecab", "cgb", "gbdefca", "cg", "fgcdab", "egfdb", "bfceg"  },
                OutputDigits = new[] { "gbdfcae", "bgc", "cg", "cgb"  }
            },
            new Line()
            {
                DigitCodes = new[] { "gcafb", "gcf", "dcaebfg", "ecagb", "gf", "abcdeg", "gaef", "cafbge", "fdbac", "fegbdc"  },
                OutputDigits = new[] { "fgae", "cfgab", "fg", "bagce"  }
            },
        };
    }
}
