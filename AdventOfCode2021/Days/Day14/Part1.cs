namespace AdventOfCode2021.Days.Day14
{
    using System.Text;

    public class Part1 : Solution<long>
    {
        public override long Apply(string[] input) => GetResultAfter10Steps(PolimerizationState.Parse(input));

        public static long GetResultAfter10Steps(PolimerizationState state)
        {
            var resultState = Enumerable.Range(0, 10).Aggregate(state, (s, _) => ApplyStep(s));

            var charCounts = resultState.Template.Distinct().ToArray();

            return charCounts.Max(c => resultState.Template.LongCount(_ => _ == c)) -
                charCounts.Min(c => resultState.Template.LongCount(_ => _ == c));
        }

        public static PolimerizationState ApplyStep(PolimerizationState input)
        {
            var resultTemplate = new StringBuilder(input.Template);

            for (var i = 0; i < resultTemplate.Length - 1; i += 2)
            {
                resultTemplate.Insert(i + 1, input.Rules[(resultTemplate[i], resultTemplate[i + 1])]);
            }

            return new PolimerizationState(resultTemplate.ToString(), input.Rules);
        }
    }
}
