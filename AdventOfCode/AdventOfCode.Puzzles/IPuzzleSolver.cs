using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles;

public interface IPuzzleSolver
{
    string Day { get; }

    string SolvePartOne(FileData fileData);

    string SolvePartTwo(FileData fileData);
}