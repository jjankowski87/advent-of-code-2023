using AdventOfCode.Puzzles.Days._06;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._06;

public class SolvePartTwoTests : TestBase<Day06PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartTwo("06.txt");
        
        // then
        result.Should().Be("71503");
    }
}