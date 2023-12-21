using AdventOfCode.Puzzles.Days._01;
using AdventOfCode.Puzzles.Days._02;
using AdventOfCode.Puzzles.Days._03;
using AdventOfCode.Puzzles.Days._04;
using AdventOfCode.Puzzles.Days._05;
using AdventOfCode.Puzzles.Days._06;
using AdventOfCode.Puzzles.Days._07;

namespace AdventOfCode.Puzzles;

public static class PuzzleSolverFactory
{
    public static IEnumerable<IPuzzleSolver> Build()
    {
        yield return new Day07PuzzleSolver();
        yield return new Day06PuzzleSolver();
        yield return new Day05PuzzleSolver();
        yield return new Day04PuzzleSolver();
        yield return new Day03PuzzleSolver();
        yield return new Day02PuzzleSolver();
        yield return new Day01PuzzleSolver();
    }
}