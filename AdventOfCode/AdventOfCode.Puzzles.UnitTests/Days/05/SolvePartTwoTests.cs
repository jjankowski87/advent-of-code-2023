using AdventOfCode.Puzzles.Days._05;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._05;

public class SolvePartTwoTests : TestBase<Day05PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartTwo("05.txt");
        
        // then
        result.Should().Be("46");
    }
}