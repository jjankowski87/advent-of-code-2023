namespace AdventOfCode.Puzzles.Days._04;

internal record Scratchcard(int CardNumber, int Matches)
{
    public bool IsWinning => Matches > 0;
}