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
        var allScratchCards = fileData.Lines.Select(ParseScratchcard).ToList();
        var resultScratchCards = allScratchCards.ToList();
        var toProcess = new Queue<Scratchcard>(allScratchCards.Where(x => x.IsWinning));

        while (toProcess.TryDequeue(out var winning))
        {
            var copies = allScratchCards.Where(x => x.CardNumber > winning.CardNumber
                                                    && x.CardNumber <= winning.CardNumber + winning.Matches).ToList();
            
            resultScratchCards.AddRange(copies);
            foreach (var copy in copies)
            {
                toProcess.Enqueue(copy);
            }
        }

        return resultScratchCards.Count.ToString();
    }

    private static Scratchcard ParseScratchcard(string line)
    {
        var cardNumber = int.Parse(line.Split(":").First().Replace("Card ", string.Empty));
        var winingNumbers = ParseWiningNumbers(line);
        var myNumbers = ParseMyNumbers(line);
        var matches = winingNumbers.Count(x => myNumbers.Contains(x));

        return new Scratchcard(cardNumber, matches);
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