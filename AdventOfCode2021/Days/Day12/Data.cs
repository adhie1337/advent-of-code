namespace AdventOfCode2021.Days.Day12
{
    public readonly record struct Node(string Name, bool IsSmall)
    {
        public static readonly Node Start = new Node(string.Intern("start"), true);

        public static readonly Node End = new Node(string.Intern("end"), true);

        public static Node Create(string name) => new Node(string.Intern(name), Char.IsLower(name[0]));
    }

    public class VisitedNodes : HashSet<Node>
    {
        public VisitedNodes() : base() { }

        public VisitedNodes(Node single) : this(new[] { single }) { }

        public VisitedNodes(IEnumerable<Node> contents) : base(contents) { }

        public bool IsNotVisited(Node node) => !this.Contains(node);

        public VisitedNodes Visit(Node node) => node.IsSmall ? new VisitedNodes(this.Append(node)) : this;
    }
}
