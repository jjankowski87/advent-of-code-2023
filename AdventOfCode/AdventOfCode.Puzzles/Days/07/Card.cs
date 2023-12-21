namespace AdventOfCode.Puzzles.Days._07;

internal record Card(int Value, char Type)
{
    public bool IsJoker => Type == 'J';
}
