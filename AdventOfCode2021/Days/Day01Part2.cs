namespace AdventOfCode2021.Days
{
    using System.Diagnostics;

    public static class Day01Part2
    {
        public static async Task<string?> Execute()
        {
            const string DataFilePath = "data/day01/input";
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
            var windows = ints.Zip(ints.Skip(1)).Zip(ints.Skip(2)).Select(_ => _.First.First + _.First.Second + _.Second);

            Console.WriteLine(windows.Zip(windows.Skip(1)).Count(_ => _.First < _.Second));

            return default;
        }
    }
}
