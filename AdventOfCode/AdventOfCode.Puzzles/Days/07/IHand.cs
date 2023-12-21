namespace AdventOfCode.Puzzles.Days._07;

internal interface IHand
{
    HandType HandType { get; }

    string Hand { get; }

    Card FirstCard { get; }

    Card SecondCard { get; }

    Card ThirdCard { get; }

    Card FourthCard { get; }

    Card FifthCard { get; }
}