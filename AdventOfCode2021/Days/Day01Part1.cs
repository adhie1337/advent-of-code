namespace AdventOfCode2021.Days
{
    public class Day01Part1 : Solution<int>
    {
        public override int Apply(string[] input)
        {
            var ints = input.Select(int.Parse);
            var result = ints.Zip(ints.Skip(1)).Count(_ => _.First < _.Second);
            return result;
        }
    }
}
