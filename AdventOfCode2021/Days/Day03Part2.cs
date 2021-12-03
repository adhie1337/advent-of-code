namespace AdventOfCode2021.Days
{
    public class Day03Part2 : Solution<int>
    {
        public override int Apply(string[] input) => Compute(input);

        public static int Compute(string[] input)
        {
            var oxigenGeneratorRating = GetOxigenGeneratorRating(input);
            var co2ScrubberRating = GetCo2ScrubberRating(input);

            var result = oxigenGeneratorRating * co2ScrubberRating;

            return result;
        }

        public static int GetOxigenGeneratorRating(string[] input) => CalculateReportValue(input, true);

        public static int GetCo2ScrubberRating(string[] input) => CalculateReportValue(input, false);

        public static int CalculateReportValue(string[] input, bool isO2Report)
        {
            var wordLength = input[0].Length;
            var oxigenGeneratorRatingValues = input.ToList();
            var digitIndex = 0;

            while (oxigenGeneratorRatingValues.Count > 1 && digitIndex < wordLength)
            {
                var mostCommon = Day03Part1.GetMostCommonBits(oxigenGeneratorRatingValues, true)[digitIndex];
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

            return Day03Part1.ToInt(oxigenGeneratorRatingValues[0].Select(_ => _ == '1').ToArray());
        }
    }
}
