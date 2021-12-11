namespace AdventOfCode2021.Days.Day03
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input) => CalculatePowerConsumpltionReport(input).ToInt();

        public static PowerConsumpltionReport CalculatePowerConsumpltionReport(string[] input)
            => CalculatePowerConsumpltionReport(GetMostCommonBits(input));

        private static PowerConsumpltionReport CalculatePowerConsumpltionReport(bool?[] commonBits)
            => new PowerConsumpltionReport()
            {
                GammaRate = ToInt(commonBits.Select(_ => _!.Value)),
                EpsilonRate = ToInt(commonBits.Select(_ => !_!.Value)),
            };

        public static int ToInt(IEnumerable<bool> commonBits) => commonBits.Aggregate(0, (a, b) => a * 2 + (b ? 1 : 0));

        public static bool?[] GetMostCommonBits(IEnumerable<string> lines, bool? defaultIsOne = null)
        {
            var lineCount = lines.Count();
            var wordLength = lines.FirstOrDefault()?.Length ?? 0;
            var oneCounts = new int[wordLength];

            foreach(var line in lines)
            {
                for(var i = 0; i < wordLength; ++i)
                {
                    if(line[i] == '1') oneCounts[i]++;
                }
            }

            var result = new bool?[wordLength];

            for(var i = 0; i < wordLength; ++i)
            {
                result[i] = oneCounts[i] == lineCount / 2.0 ? null : oneCounts[i] > lineCount / 2;
            }

            return result;
        }
    }
}
