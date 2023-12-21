namespace AdventOfCode.Puzzles.Days._08;

internal class Node : INode
{
    private Node? _left;

    private Node? _right;
    
    public Node(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public INode GoLeft()
    {
        return _left ?? throw new InvalidOperationException($"Node {Name} has no Left path");
    }

    public INode GoRight()
    {
        return _right ?? throw new InvalidOperationException($"Node {Name} has no Rigth path");
    }

    public void SetLeftPath(Node node)
    {
        _left = node;
    }

    public void SetRightPath(Node node)
    {
        _right = node;
    }
}