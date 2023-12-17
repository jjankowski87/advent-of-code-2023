namespace AdventOfCode.Puzzles.Days._02;

internal class PossibilityDeterminator
{
    private readonly int _red;

    private readonly int _green;

    private readonly int _blue;

    public PossibilityDeterminator(int red, int green, int blue)
    {
        _red = red;
        _green = green;
        _blue = blue;
    }

    public bool IsPossible(IEnumerable<Grab> grabs)
    {
        foreach (var grab in grabs)
        {
            if (grab.Red > _red || grab.Green > _green || grab.Blue > _blue)
            {
                return false;
            }
        }

        return true;
    }

    public int GetPower(IEnumerable<Grab> grabs)
    {
        var red = 0;
        var green = 0;
        var blue = 0;
        
        foreach (var grab in grabs)
        {
            red = Math.Max(red, grab.Red);
            green = Math.Max(green, grab.Green);
            blue = Math.Max(blue, grab.Blue);
        }

        return red * green * blue;
    }
}