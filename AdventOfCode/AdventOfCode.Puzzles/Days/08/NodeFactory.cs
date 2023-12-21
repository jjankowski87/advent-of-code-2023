namespace AdventOfCode.Puzzles.Days._08;

internal static class NodeFactory
{
    public static INode BuildNodes(IEnumerable<string> nodeLines, string startingNode)
    {
        return BuildNodesDictionary(nodeLines)[startingNode];
    }

    public static IList<INode> BuildNodes(IEnumerable<string> nodeLines)
    {
        return BuildNodesDictionary(nodeLines).Select(x => x.Value).ToList<INode>();
    }

    private static IDictionary<string, Node> BuildNodesDictionary(IEnumerable<string> nodeLines)
    {
        var nodes = nodeLines.Select(ParseNodeLine).ToList();
        var nodesDictionary = nodes.ToDictionary(x => x.Node.Name, x => x.Node);

        foreach (var node in nodes)
        {
            node.Node.SetLeftPath(nodesDictionary[node.Left]);
            node.Node.SetRightPath(nodesDictionary[node.Right]);
        }

        return nodesDictionary;
    }

    private static (Node Node, string Left, string Right) ParseNodeLine(string nodeLine)
    {
        var parts = nodeLine.Split(" = ");
        var paths = parts[1].Trim().Replace("(", string.Empty).Replace(")", string.Empty).Split(", ");

        return (new Node(parts[0]), paths[0], paths[1]);
    }
}