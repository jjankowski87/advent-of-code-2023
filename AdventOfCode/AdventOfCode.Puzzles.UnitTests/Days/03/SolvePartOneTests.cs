using AdventOfCode.Puzzles.Days._03;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._03;

public class SolvePartOneTests : TestBase<Day03PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartOne("03.txt");
        
        // then
        result.Should().Be("4361");
    }
}