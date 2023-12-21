namespace AdventOfCode.Puzzles.Days._06;

internal static class RaceCalculator
{
    public static int CalculateWinningRaces(Race race)
    {
        var result = 0;
        for (long i = 1; i < race.Duration; i++)
        {
            var raceDistance = CalculateRaceDistance(i, race.Duration);
            if (raceDistance > race.Distance)
            {
                result++;
            }
        }

        return result;
    }

    private static long CalculateRaceDistance(long timePushingButton, long totalRaceDuration)
    {
        var speed = timePushingButton;
        var timeToRace = totalRaceDuration - timePushingButton;

        return timeToRace * speed;
    }
}