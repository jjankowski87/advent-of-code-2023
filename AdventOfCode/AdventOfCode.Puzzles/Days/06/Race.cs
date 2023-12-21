namespace AdventOfCode.Puzzles.Days._06;

internal class Race
{
    public Race(long duration, long distance)
    {
        Duration = duration;
        Distance = distance;
    }

    public long Duration { get; }

    public long Distance { get; }
}