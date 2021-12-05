namespace AdventOfCode2021.Days.Day01
{
    public class Part2 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var ints = input.Select(int.Parse);
            var windows = ints.Zip(ints.Skip(1))
                .Zip(ints.Skip(2))
                .Select(_ => _.First.First + _.First.Second + _.Second);
            var result = windows.Zip(windows.Skip(1))
                .Count(_ => _.First < _.Second);
            return result;
        }
    }
}
