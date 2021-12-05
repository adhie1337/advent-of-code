namespace AdventOfCode2021.Days.Day03
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var commonBits = GetMostCommonBits(input);

            var gammaRate = ToInt(commonBits.Select(_ => _!.Value));
            var epsilonRate = ToInt(commonBits.Select(_ => !_!.Value));

            var result = gammaRate * epsilonRate;

            return result;
        }

        public static int ToInt(IEnumerable<bool> commonBits)
        {
            var result = 0;

            foreach (var actualBitIsOne in commonBits)
            {
                result *= 2;

                if (actualBitIsOne) result++;
            }

            return result;
        }

        public static bool?[] GetMostCommonBits(IEnumerable<string> lines, bool? defaultIsOne = null)
        {
            var lineCount = lines.Count();
            var wordLength = lines.First().Length;
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
