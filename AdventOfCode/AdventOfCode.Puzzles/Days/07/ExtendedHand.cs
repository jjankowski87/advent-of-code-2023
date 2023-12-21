namespace AdventOfCode.Puzzles.Days._07;

internal class ExtendedHand : IHand
{
    private readonly List<Card> _cards;

    public ExtendedHand(ICollection<Card> cards)
    {
        if (cards.Count != 5)
        {
            throw new InvalidOperationException("Invalid number of cards in hand");
        }

        _cards = cards.ToList();
        HandType = GetHandType(_cards);
    }

    public HandType HandType { get; }

    public Card FirstCard => _cards[0];
    
    public Card SecondCard => _cards[1];

    public Card ThirdCard => _cards[2];

    public Card FourthCard => _cards[3];

    public Card FifthCard => _cards[4];

    public string Hand => new(_cards.Select(x => x.Type).ToArray());

    private static HandType GetHandType(IEnumerable<Card> cards)
    {
        var group = cards.GroupBy(x => x)
            .Select(x => new { Card = x.Key, CardType = x.Key.Type, Count = x.Count() })
            .ToList();
        if (group.Count == 5)
        {
            if (group.Any(x => x.Card.IsJoker))
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }

        if (group.Count == 4)
        {
            var pair = group.First(x => x.Count == 2);
            if (group.Any(x => x.Card.IsJoker))
            {
                return HandType.ThreeOfAKind;
            }

            return HandType.OnePair;
        }

        if (group.Count == 3)
        {
            var jokers = group.FirstOrDefault(x => x.Card.IsJoker);
            if (jokers != null)
            {
                if (group.Any(x => x.Count == 3))
                {
                    return HandType.FourOfAKind;
                }

                if (jokers.Count == 2)
                {
                    return HandType.FourOfAKind;
                }

                return HandType.FullHouse;
            }

            if (group.Any(x => x.Count == 3))
            {
                return HandType.ThreeOfAKind;
            }

            return HandType.TwoPair;
        }

        if (group.Count == 2)
        {
            if (group.Any(x => x.Card.IsJoker))
            {
                return HandType.FiveOfAKind;
            }

            if (group.Any(x => x.Count == 4))
            {
                return HandType.FourOfAKind;
            }

            return HandType.FullHouse;
        }

        return HandType.FiveOfAKind;
    }
}