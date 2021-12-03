namespace AdventOfCode2021.Days
{
    public class Day03Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var wordLength = input[0].Length;
            var oneCounts = new int[wordLength];

            foreach(var line in input)
            {
                for(var i = 0; i < wordLength; ++i)
                {
                    if(line[i] == '1') oneCounts[i]++;
                }
            }

            var gammaRate = 0;
            var epsilonRate = 0;

            for(var i = 0; i < wordLength; ++i)
            {
                gammaRate *= 2;
                epsilonRate *= 2;

                if(oneCounts[i] > input.Length / 2) gammaRate++;
                else epsilonRate++;
            }

            var result = gammaRate * epsilonRate;

            return result;
        }
    }
}
