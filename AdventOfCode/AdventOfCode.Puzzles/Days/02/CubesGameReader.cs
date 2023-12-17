namespace AdventOfCode.Puzzles.Days._02;

public record Grab(int Red, int Green, int Blue);

internal static class CubesGameReader
{
    public static IEnumerable<Grab> ParseLine(string line)
    {
        var grab = line.Split(":").Last().Split(";");

        foreach (var singleGrab in grab)
        {
            var red = GetNumberOfCubes(singleGrab, "red");
            var green = GetNumberOfCubes(singleGrab, "green");
            var blue = GetNumberOfCubes(singleGrab, "blue");

            yield return new Grab(red, green, blue);
        }
    }

    private static int GetNumberOfCubes(string cubes, string color)
    {
        if (!cubes.Contains(color))
        {
            return 0;
        }

        var number = cubes.Split(",").First(x => x.Contains(color))
            .Replace(color, string.Empty, StringComparison.InvariantCultureIgnoreCase)
            .Trim();
        return int.Parse(number);
    }
}