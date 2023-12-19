using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._05;

public class Day05PuzzleSolver : IPuzzleSolver
{
    public string Day => "05";

    public string SolvePartOne(FileData fileData)
    {
        var puzzleInput = ParseFirstPuzzleInput(fileData);
        var sourceType = "seed";
        var lowestLocation = long.MaxValue;

        foreach (var seed in puzzleInput.Seeds)
        {
            var number = seed;
            while (true)
            {
                var gardenMapping = puzzleInput.GardenMappings.SingleOrDefault(x => x.Source == sourceType);
                if (gardenMapping == null)
                {
                    break;
                }

                number = gardenMapping.Map(number);
                sourceType = gardenMapping.Destination;
            }

            sourceType = "seed";
            if (number < lowestLocation)
            {
                lowestLocation = number;
            }
        }

        return lowestLocation.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var puzzleInput = ParseSecondPuzzleInput(fileData);
        var sourceType = "seed";
        var lowestLocation = long.MaxValue;

        foreach (var seed in puzzleInput.Seeds)
        {
            var ranges = new MyRanges(seed);
            while (true)
            {
                var gardenMapping = puzzleInput.GardenMappings.SingleOrDefault(x => x.Source == sourceType);
                if (gardenMapping == null)
                {
                    break;
                }

                ranges = new MyRanges(ranges.Items.SelectMany(x => gardenMapping.MapRanges(x)));
                sourceType = gardenMapping.Destination;
            }

            sourceType = "seed";
            var destinationNumber = ranges.GetLowestValue();
            if (destinationNumber < lowestLocation)
            {
                lowestLocation = destinationNumber;
            }
        }

        return lowestLocation.ToString();
    }

    private static FirstPuzzle ParseFirstPuzzleInput(FileData fileData)
    {
        var seeds = fileData.Lines.First().Replace("seeds: ", string.Empty)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToList();

        return new FirstPuzzle(seeds, ParseGardenMappings(fileData));
    }

    private static SecondPuzzle ParseSecondPuzzleInput(FileData fileData)
    {
        var seeds = fileData.Lines.First().Replace("seeds: ", string.Empty)
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToList();

        var seedRanges = new List<MyRange>();
        for (var i = 0; i < seeds.Count - 1; i += 2)
        {
            // destination range start, the source range start, and the range length.
            seedRanges.Add(new MyRange(seeds[i], seeds[i + 1]));
        }

        return new SecondPuzzle(seedRanges, ParseGardenMappings(fileData));
    }

    private static List<GardenMapping> ParseGardenMappings(FileData fileData)
    {
        var gardenMapping = new List<GardenMapping>();

        var isFirstLine = true;
        var source = string.Empty;
        var destination = string.Empty;
        var mappings = new List<SingleMapping>();

        foreach (var line in fileData.Lines.Skip(2))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                gardenMapping.Add(new GardenMapping(source, destination, mappings));

                isFirstLine = true;
                source = string.Empty;
                destination = string.Empty;
                mappings = new List<SingleMapping>();
            }
            else if (isFirstLine)
            {
                var mappingDetails = line.Split(" ").First().Split("-");
                source = mappingDetails.First();
                destination = mappingDetails.Last();
                isFirstLine = false;
            }
            else
            {
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                mappings.Add(new SingleMapping(parts[0], parts[1], parts[2]));
                isFirstLine = false;
            }
        }

        gardenMapping.Add(new GardenMapping(source, destination, mappings));
        return gardenMapping;
    }
}