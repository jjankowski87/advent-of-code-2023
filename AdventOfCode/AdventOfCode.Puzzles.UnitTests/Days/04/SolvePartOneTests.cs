using AdventOfCode.Puzzles.Days._04;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._04;

public class SolvePartOneTests : TestBase<Day04PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("04.txt");
        
        // then
        result.Should().Be("13");
    }
}