using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.UnitTests.Infrastructure;

public abstract class TestBase<TTestCandidate>
    where TTestCandidate : IPuzzleSolver, new()
{
    protected TTestCandidate TestCandidate => new();

    protected string SolvePartOne(string fileName)
    {
        var lines = File.ReadAllLines($"Data/{fileName}");

        return TestCandidate.SolvePartOne(new FileData(lines));
    }

    protected string SolvePartTwo(string fileName)
    {
        var lines = File.ReadAllLines($"Data/{fileName}");

        return TestCandidate.SolvePartTwo(new FileData(lines));
    }
}