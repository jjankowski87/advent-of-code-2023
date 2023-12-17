using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._02;

public class Day02PuzzleSolver : IPuzzleSolver
{
    public string Day => "02";

    public string SolvePartOne(FileData fileData)
    {
        var determinator = new PossibilityDeterminator(12, 13, 14);
        var gameNumber = 1;
        var sum = 0;

        foreach (var line in fileData.Lines)
        {
            var grabs = CubesGameReader.ParseLine(line).ToList();
            if (determinator.IsPossible(grabs))
            {
                sum += gameNumber;
            }

            gameNumber++;
        }

        return sum.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var determinator = new PossibilityDeterminator(12, 13, 14);
        var power = 0;

        foreach (var line in fileData.Lines)
        {
            var grabs = CubesGameReader.ParseLine(line).ToList();
            power += determinator.GetPower(grabs);
        }

        return power.ToString();
    }
}