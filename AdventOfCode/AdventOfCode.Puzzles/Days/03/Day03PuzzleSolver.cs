using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._03;

public class Day03PuzzleSolver : IPuzzleSolver
{
    public string Day => "03";

    public string SolvePartOne(FileData fileData)
    {
        var sum = MachineSchemeReader.FindPartNumbers(fileData.Lines)
            .Where(x => x.IsValid(fileData.Lines))
            .Aggregate(0, (x, part) => x + part.Value);

        return sum.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        return MachineSchemeReader.FindPartNumbers(fileData.Lines)
            .Select(x =>
            new {
                Part = x,
                Position = x.GearPosition(fileData.Lines),
            })
            .Where(x => x.Position != null)
            .GroupBy(x => x.Position)
            .Where(x => x.Count() == 2)
            .Select(x => x.Aggregate(1, (a, b) => a * b.Part.Value))
            .Sum()
            .ToString();
    }
}