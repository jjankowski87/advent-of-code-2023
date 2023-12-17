using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._04;

public class Day04PuzzleSolver : IPuzzleSolver
{
    public string Day => "04";

    public string SolvePartOne(FileData fileData)
    {
        var sum = 0;
        foreach (var line in fileData.Lines)
        {
            var winingNumbers = ParseWiningNumbers(line);
            var myNumbers = ParseMyNumbers(line);

            var matches = winingNumbers.Count(x => myNumbers.Contains(x));
            if (matches == 0)
            {
                continue;
            }

            if (matches == 1)
            {
                sum += 1;
                continue;
            }

            sum += (int)Math.Pow(2, matches - 1);
        }

        return sum.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        throw new NotImplementedException();
    }

    private static IList<int> ParseMyNumbers(string line)
    {
        var numbers = line.Split(":").Last().Split("|").Last().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return numbers.Select(int.Parse).ToList();
     }

    private static IList<int> ParseWiningNumbers(string line)
    {
        var numbers = line.Split(":").Last().Split("|").First().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return numbers.Select(int.Parse).ToList();
    }
}