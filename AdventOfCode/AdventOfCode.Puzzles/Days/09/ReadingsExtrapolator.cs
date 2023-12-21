namespace AdventOfCode.Puzzles.Days._09;

internal static class ReadingsExtrapolator
{
    public static int Extrapolate(Readings readings)
    {
        if (readings.Values.All(x => x == 0))
        {
            return 0;
        }

        var extrapolated = new Readings(readings.Values.Skip(1).Select((x, i) => x - readings.Values[i]).ToList());
        var extrapolation = Extrapolate(extrapolated);

        return extrapolation + readings.Values.Last();
    }

    public static int ExtrapolateBackwards(Readings readings)
    {
        if (readings.Values.All(x => x == 0))
        {
            return 0;
        }

        var extrapolated = new Readings(readings.Values.Skip(1).Select((x, i) => x - readings.Values[i]).ToList());
        var extrapolation = ExtrapolateBackwards(extrapolated);

        return readings.Values.First() - extrapolation;
    }
}