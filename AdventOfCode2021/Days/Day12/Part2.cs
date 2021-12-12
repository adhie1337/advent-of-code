namespace AdventOfCode2021.Days.Day12
{
    public class Part2 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => CountPaths(input.Select(line => line.Split('-')));

        public static ulong CountPaths(IEnumerable<string[]> edges)
            => CountPaths(Node.Start, CreateMap(edges), new VisitedNodes(Node.Start), false);

        public static Dictionary<Node, Node[]> CreateMap(IEnumerable<string[]> edges)
            => edges.SelectMany(edge => new (string Start, string End)[] { (edge[0], edge[1]), (edge[1], edge[0]) })
                .GroupBy(edge => edge.Start)
                .ToDictionary(group => Node.Create(group.Key), group => group.Select(edge => Node.Create(edge.End)).ToArray());

        public static ulong CountPaths(Node currentNode, Dictionary<Node, Node[]> map, VisitedNodes visited, bool twice)
            => currentNode != Node.End
                ? map[currentNode].Where(node => node != Node.Start && (visited.IsNotVisited(node) || !twice))
                    .Aggregate((ulong)0, (a, node) => a + CountPaths(node, map, visited.Visit(node), twice || visited.Contains(node)))
                : 1;
    }
}
