namespace AdventOfCode.Puzzles.Days._07;

internal static class CardFactory
{
    private static readonly IDictionary<char, int> StandardRules = new Dictionary<char, int>
    {
        { 'A', 13 },
        { 'K', 12 },
        { 'Q', 11 },
        { 'J', 10 },
        { 'T', 9 },
        { '9', 8 },
        { '8', 7 },
        { '7', 6 },
        { '6', 5 },
        { '5', 4 },
        { '4', 3 },
        { '3', 2 },
        { '2', 1 },
    };

    private static readonly IDictionary<char, int> ExtendedRules = new Dictionary<char, int>
    {
        { 'A', 13 },
        { 'K', 12 },
        { 'Q', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
        { 'J', 1 },
    };

    public static Card CreateStandardRules(char value)
    {
        return new Card(StandardRules[value], value);
    }

    public static Card CreateExtendedRules(char value)
    {
        return new Card(ExtendedRules[value], value);
    }
}