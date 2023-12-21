using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._09;

public class Day09PuzzleSolver : IPuzzleSolver
{
    public string Day => "09";

    public string SolvePartOne(FileData fileData)
    {
        var result = ParseInput(fileData)
            .Select(ReadingsExtrapolator.Extrapolate)
            .Sum();

        return result.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var result = ParseInput(fileData)
            .Select(ReadingsExtrapolator.ExtrapolateBackwards)
            .Sum();

        return result.ToString();
    }

    private static IEnumerable<Readings> ParseInput(FileData fileData)
    {
        foreach (var line in fileData.Lines)
        {
            yield return new Readings(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList());
        }
    }
}