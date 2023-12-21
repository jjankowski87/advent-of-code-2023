﻿using AdventOfCode.Puzzles.Days._07;
using AdventOfCode.Puzzles.UnitTests.Infrastructure;
using FluentAssertions;

namespace AdventOfCode.Puzzles.UnitTests.Days._07;

public class SolvePartTwoTests : TestBase<Day07PuzzleSolver>
{
    [Fact]
    public void ShouldSolveTestPuzzle()
    {
        // given && when
        var result = SolvePartTwo("07.txt");
        
        // then
        result.Should().Be("5905");
    }
}