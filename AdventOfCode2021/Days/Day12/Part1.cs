namespace AdventOfCode2021.Days.Day12
{
    public class Part1 : Solution<ulong>
    {
        public override ulong Apply(string[] input) => CountPaths(input.Select(line => line.Split('-')));

        public static ulong CountPaths(IEnumerable<string[]> edges)
            => CountPaths(Node.Start, CreateMap(edges), new VisitedNodes(Node.Start));

        public static Dictionary<Node, Node[]> CreateMap(IEnumerable<string[]> edges)
            => edges.SelectMany(edge => new (string Start, string End)[] { (edge[0], edge[1]), (edge[1], edge[0]) })
                .GroupBy(edge => edge.Start)
                .ToDictionary(group => Node.Create(group.Key), group => group.Select(edge => Node.Create(edge.End)).ToArray());

        public static ulong CountPaths(Node currentNode, Dictionary<Node, Node[]> map, VisitedNodes visited)
            => currentNode != Node.End
                ? map[currentNode].Where(visited.IsNotVisited)
                    .Aggregate((ulong)0, (act, node) => act + CountPaths(node, map, visited.Visit(node)))
                : 1;
    }
}
