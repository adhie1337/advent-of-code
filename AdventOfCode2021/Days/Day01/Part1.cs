namespace AdventOfCode2021.Days.Day01
{
    public class Part1 : Solution<int>
    {
        public override int Apply(string[] input)
            => CountIncreases(input.Select(int.Parse));

        public static int CountIncreases(IEnumerable<int> ints)
            => ints.Zip(ints.Skip(1)).Count(_ => _.First < _.Second);
    }
}
