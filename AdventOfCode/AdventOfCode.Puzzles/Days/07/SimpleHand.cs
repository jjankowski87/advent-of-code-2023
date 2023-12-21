namespace AdventOfCode.Puzzles.Days._07;

internal class SimpleHand : IHand
{
    private readonly List<Card> _cards;

    public SimpleHand(ICollection<Card> cards)
    {
        if (cards.Count != 5)
        {
            throw new InvalidOperationException("Invalid number of cards in hand");
        }

        _cards = cards.ToList();
        HandType = GetHandType(_cards);
    }

    public HandType HandType { get; }

    public string Hand => new(_cards.Select(x => x.Type).OrderBy(x => x).ToArray());

    public Card FirstCard => _cards[0];
    
    public Card SecondCard => _cards[1];

    public Card ThirdCard => _cards[2];

    public Card FourthCard => _cards[3];

    public Card FifthCard => _cards[4];

    private static HandType GetHandType(IEnumerable<Card> cards)
    {
        var group = cards.GroupBy(x => x).ToList();
        if (group.Count == 5)
        {
            return HandType.HighCard;
        }

        if (group.Count == 4)
        {
            return HandType.OnePair;
        }

        if (group.Count == 3)
        {
            return group.Any(x => x.Count() == 3)
                ? HandType.ThreeOfAKind
                : HandType.TwoPair;
        }

        if (group.Count == 2)
        {
            return group.Any(x => x.Count() == 4)
                ? HandType.FourOfAKind
                : HandType.FullHouse;
        }

        return HandType.FiveOfAKind;
    }
}