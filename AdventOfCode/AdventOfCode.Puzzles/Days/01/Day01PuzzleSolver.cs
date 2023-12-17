using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._01;

public class Day01PuzzleSolver : IPuzzleSolver
{
    public string Day => "01";

    public string SolvePartOne(FileData fileData)
    {
        throw new NotImplementedException();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var sum = 0;

        foreach (var line in fileData.Lines)
        {
            var number = DigitFinder.FindTwoDigitNumber(line);
            sum += number;
        }

        return sum.ToString();
    }
}