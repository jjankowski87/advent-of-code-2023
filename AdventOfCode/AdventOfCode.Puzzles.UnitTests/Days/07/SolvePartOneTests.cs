using AdventOfCode.Puzzles.Days._07;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._07;

public class SolvePartOneTests : TestBase<Day07PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("07.txt");
        
        // then
        result.Should().Be("6440");
    }
}