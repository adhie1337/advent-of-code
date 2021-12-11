namespace AdventOfCode2021.Days.Day03
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input) => CalculateLifeSupportReport(input).ToInt();

        public static LifeSupportReport CalculateLifeSupportReport(string[] input)
        {
            var oxigenGeneratorRating = GetOxigenGeneratorRating(input);
            var co2ScrubberRating = GetCo2ScrubberRating(input);

            return new LifeSupportReport(oxigenGeneratorRating, co2ScrubberRating);
        }

        public static int GetOxigenGeneratorRating(string[] input) => CalculateReportValue(input, true);

        public static int GetCo2ScrubberRating(string[] input) => CalculateReportValue(input, false);

        public static int CalculateReportValue(string[] input, bool isO2Report)
        {
            var wordLength = input.FirstOrDefault()?.Length ?? 0;
            var oxigenGeneratorRatingValues = input.ToList();
            var digitIndex = 0;

            while (oxigenGeneratorRatingValues.Count > 1 && digitIndex < wordLength)
            {
                var mostCommon = Part1.GetMostCommonBits(oxigenGeneratorRatingValues, true)[digitIndex];
                var mostCommonDigit = mostCommon.HasValue ? mostCommon.Value ? (char?)'1' : '0' : null;

                for (var i = 0; i < oxigenGeneratorRatingValues.Count && oxigenGeneratorRatingValues.Count > 1; ++i)
                {
                    var currentDigit = oxigenGeneratorRatingValues[i][digitIndex];
                    var currentDigitIsMostCommon = mostCommonDigit == currentDigit;

                    if (mostCommonDigit.HasValue && currentDigitIsMostCommon != isO2Report
                        || !mostCommonDigit.HasValue && currentDigit != (isO2Report ? '1' : '0'))
                    {
                        oxigenGeneratorRatingValues.RemoveAt(i--);
                    }
                }

                digitIndex++;
            }

            return Part1.ToInt(oxigenGeneratorRatingValues.SelectMany(_ => _.Select(_ => _ == '1')).ToArray());
        }
    }
}
