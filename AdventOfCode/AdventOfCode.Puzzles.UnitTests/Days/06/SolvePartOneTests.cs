using AdventOfCode.Puzzles.Days._06;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._06;

public class SolvePartOneTests : TestBase<Day06PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("06.txt");
        
        // then
        result.Should().Be("288");
    }
}