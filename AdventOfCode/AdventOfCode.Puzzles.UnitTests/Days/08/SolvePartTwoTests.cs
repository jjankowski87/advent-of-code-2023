using AdventOfCode.Puzzles.Days._08;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._08;

public class SolvePartTwoTests : TestBase<Day08PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartTwo("08c.txt");
        
        // then
        result.Should().Be("6");
    }
}