using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._06;

public class Day06PuzzleSolver : IPuzzleSolver
{
    public string Day => "06";

    public string SolvePartOne(FileData fileData)
    {
        var races = ParseRaces(fileData);
        var result = races.Select(RaceCalculator.CalculateWinningRaces).Aggregate(1, (x, y) => x * y);

        return result.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var race = ParseRace(fileData);
        var result = RaceCalculator.CalculateWinningRaces(race);

        return result.ToString();
    }

    private static IList<Race> ParseRaces(FileData fileData)
    {
        var durations = ParseLine(fileData.Lines[0].Replace("Time:", string.Empty));
        var distances = ParseLine(fileData.Lines[1].Replace("Distance:", string.Empty));

        return durations.Zip(distances).Select(x => new Race(x.First, x.Second)).ToList();
    }

    private static Race ParseRace(FileData fileData)
    {
        var durations = ParseLine(fileData.Lines[0].Replace("Time:", string.Empty).Replace(" ", string.Empty));
        var distances = ParseLine(fileData.Lines[1].Replace("Distance:", string.Empty).Replace(" ", string.Empty));

        return new Race(durations.First(), distances.First());
    }

    private static IEnumerable<long> ParseLine(string line)
    {
        return line.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
    }
}