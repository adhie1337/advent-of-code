namespace AdventOfCode2021.Tests.Days.Day18
{
    using AdventOfCode2021.Days.Day18;
    using static AdventOfCode2021.Days.Day18.Number;

    public static class Example
    {
        public static readonly INumber[] Homework = new[]
        {
            Parse("[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]"),
            Parse("[[[5,[2,8]],4],[5,[[9,9],0]]]"),
            Parse("[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]"),
            Parse("[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]"),
            Parse("[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]"),
            Parse("[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]"),
            Parse("[[[[5,4],[7,7]],8],[[8,3],8]]"),
            Parse("[[9,3],[[9,9],[6,[4,9]]]]"),
            Parse("[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]"),
            Parse("[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"),
        };
    }
}
