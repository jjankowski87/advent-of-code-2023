using AdventOfCode.Puzzles.Days._03;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._03;

public class SolvePartTwoTests : TestBase<Day03PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartTwo("03.txt");
        
        // then
        result.Should().Be("467835");
    }
}