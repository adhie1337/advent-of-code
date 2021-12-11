namespace AdventOfCode2021.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using AdventOfCode2021.Days.Day10;

    [TestClass]
    public class Day10Tests
    {
        public static string[] ExampleInput = new[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        [TestMethod]
        public void CalculateSyntaxErrorScore_ForExample_Returns26397()
        {
            var input = ExampleInput;

            var result = Part1.CalculateSyntaxErrorScore(input);

            Assert.AreEqual(26397, result);
        }

        [TestMethod]
        public void CalculateAutocompleteScore_ForExample_Returns288957()
        {
            var input = ExampleInput;

            var result = Part2.CalculateAutocompleteScore(input);

            Assert.AreEqual<ulong>(288957, result);
        }
    }
}
