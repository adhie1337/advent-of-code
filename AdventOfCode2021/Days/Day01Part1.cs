namespace AdventOfCode2021.Days
{
    using System.Diagnostics;

    public static class Day01Part1
    {
        public static async Task<string?> Execute()
        {
            const string DataFilePath = "data/day1/input";
            var file = new FileInfo(DataFilePath);

            if (!file.Exists)
            {
                return $"File not exists, please download input file to {DataFilePath}...";
            }
            else
            {
                Debug.WriteLine($"Found file at {DataFilePath} with { file.Length } bytes!");
            }

            var data = await File.ReadAllLinesAsync(DataFilePath);
            var ints = data.Select(int.Parse);

            Console.WriteLine(ints.Zip(ints.Skip(1)).Count(_ => _.First < _.Second));

            return default;
        }
    }
}
