using AdventOfCode.Puzzles.Days._05;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._05;

public class SolvePartOneTests : TestBase<Day05PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("05.txt");
        
        // then
        result.Should().Be("35");
    }
}