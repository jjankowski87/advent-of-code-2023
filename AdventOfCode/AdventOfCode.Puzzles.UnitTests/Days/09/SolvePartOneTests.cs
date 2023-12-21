using AdventOfCode.Puzzles.Days._09;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._09;

public class SolvePartOneTests : TestBase<Day09PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("09.txt");
        
        // then
        result.Should().Be("114");
    }
}