using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._08;

public class Day08PuzzleSolver : IPuzzleSolver
{
    public string Day => "08";

    public string SolvePartOne(FileData fileData)
    {
        const string startNode = "AAA";
        const string endNode = "ZZZ";

        var turns = 0;
        var pathToFollow = new Path(fileData.Lines.First().Trim());
        var currentNode = NodeFactory.BuildNodes(fileData.Lines.Skip(2), startNode);

        while (currentNode.Name != endNode)
        {
            currentNode = pathToFollow.Current switch
            {
                Direction.Left => currentNode.GoLeft(),
                Direction.Right => currentNode.GoRight(),
                _ => throw new ArgumentOutOfRangeException()
            };

            turns++;
            pathToFollow.MoveNext();
        }

        return turns.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var turns = 0;
        var pathToFollow = new Path(fileData.Lines.First().Trim());
        var nodes = NodeFactory.BuildNodes(fileData.Lines.Skip(2));
        var currentNodes = nodes.Where(x => x.Name.EndsWith("A")).ToArray();
        var cycles = new int[currentNodes.Length];

        while (cycles.Any(x => x == default))
        {
            for (var i = 0; i < currentNodes.Length; i++)
            {
                if (currentNodes[i].Name.EndsWith("Z"))
                {
                    if (cycles[i] == default)
                    {
                        cycles[i] = turns;
                    }

                    continue;
                }

                currentNodes[i] = pathToFollow.Current switch
                {
                    Direction.Left => currentNodes[i].GoLeft(),
                    Direction.Right => currentNodes[i].GoRight(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            turns++;
            pathToFollow.MoveNext();
        }

        var result = LeastCommonMultiple(cycles);
        return result.ToString();
    }

    private static long LeastCommonMultiple(int[] numbers)
    {
        long lcm = numbers.First();
        var num = numbers.Skip(1).ToList();

        while (num.Any())
        {
            lcm = Lcm(lcm, num.First());
            num = num.Skip(1).ToList();
        }

        return lcm;
    }

    // https://stackoverflow.com/questions/13569810/least-common-multiple
    private static long Gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long Lcm(long a, long b)
    {
        return (a / Gcf(a, b)) * b;
    }
}