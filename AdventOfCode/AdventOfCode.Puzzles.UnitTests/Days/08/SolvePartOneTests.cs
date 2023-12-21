using AdventOfCode.Puzzles.Days._08;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._08;

public class SolvePartOneTests : TestBase<Day08PuzzleSolver>
{
    [Theory]
    [InlineData("08a.txt", "2")]
    [InlineData("08b.txt", "6")]
    public void ShouldSolveTestPuzzle(string fileName, string expectedResult)
    {
        // given && when
        var result = SolvePartOne(fileName);
        
        // then
        result.Should().Be(expectedResult);
    }
}