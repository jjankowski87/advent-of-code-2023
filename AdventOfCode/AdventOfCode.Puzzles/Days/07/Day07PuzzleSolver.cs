using AdventOfCode.Puzzles.Data;

namespace AdventOfCode.Puzzles.Days._07;

public class Day07PuzzleSolver : IPuzzleSolver
{
    public string Day => "07";

    public string SolvePartOne(FileData fileData)
    {
        var hands = ParseHands(fileData, CardFactory.CreateStandardRules, x => new SimpleHand(x)).ToList();
        var result = hands.OrderBy(x => x.Hand.HandType)
            .ThenBy(x => x.Hand.FirstCard.Value)
            .ThenBy(x => x.Hand.SecondCard.Value)
            .ThenBy(x => x.Hand.ThirdCard.Value)
            .ThenBy(x => x.Hand.FourthCard.Value)
            .ThenBy(x => x.Hand.FifthCard.Value)
            .Select((x, i) => x.Bid * (i + 1))
            .Sum();

        return result.ToString();
    }

    public string SolvePartTwo(FileData fileData)
    {
        var hands = ParseHands(fileData, CardFactory.CreateExtendedRules, x => new ExtendedHand(x)).ToList();
        var result = hands.OrderBy(x => x.Hand.HandType)
            .ThenBy(x => x.Hand.FirstCard.Value)
            .ThenBy(x => x.Hand.SecondCard.Value)
            .ThenBy(x => x.Hand.ThirdCard.Value)
            .ThenBy(x => x.Hand.FourthCard.Value)
            .ThenBy(x => x.Hand.FifthCard.Value)
            .ToList();

        var xx = string.Join("\r\n", result.Select(x => $"{x.Hand.Hand} {x.Hand.HandType}"));
        
        var sum = result.Select((x, i) => x.Bid * (i + 1)).Sum();
        return sum.ToString();
    }

    private static IEnumerable<(IHand Hand, int Bid)> ParseHands(
        FileData fileData,
        Func<char, Card> cardFactory,
        Func<ICollection<Card>, IHand> handFactory)
    {
        foreach (var line in fileData.Lines)
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var hand = handFactory(parts[0].Select(cardFactory).ToList());
            var bid = int.Parse(parts[1]);

            yield return (hand, bid);
        }
    }
}