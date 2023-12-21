namespace AdventOfCode.Puzzles.Days._08;

internal interface INode
{
    string Name { get; }

    INode GoLeft();

    INode GoRight();
}