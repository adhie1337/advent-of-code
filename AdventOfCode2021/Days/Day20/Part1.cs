namespace AdventOfCode2021.Days.Day20
{
    using static Image;

    public class Part1 : Solution<long>
    {
        public override long Apply(string[] input) => CountPixelsAfter(Parse(input), 2);

        public static long CountPixelsAfter(Image image, int enhanceCount)
            => Enumerable.Range(0, enhanceCount)
                .Aggregate(image, (image, _) => Enhance(image))
                .Pixels
                .LongCount(isLit => isLit);
    }
}
