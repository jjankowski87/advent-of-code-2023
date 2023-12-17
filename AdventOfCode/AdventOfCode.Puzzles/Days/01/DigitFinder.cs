namespace AdventOfCode.Puzzles.Days._01;

internal static class DigitFinder
{
    private static readonly IDictionary<string, string> NumberMapping = new Dictionary<string, string>
    {
        { "one", "one1one" },
        { "two", "two2two" },
        { "three", "three3three" },
        { "four", "four4four" },
        { "five", "five5five" },
        { "six", "six6six" },
        { "seven", "seven7seven" },
        { "eight", "eight8eight" },
        { "nine", "nine9nine" },
    };

    public static int FindTwoDigitNumber(string line)
    {
        foreach (var (word, number) in NumberMapping)
        {
            line = line.Replace(word, number, StringComparison.InvariantCultureIgnoreCase);
        }

        var x = int.Parse(line.First(char.IsDigit).ToString());
        var y = int.Parse(line.Last(char.IsDigit).ToString());

        return x * 10 + y;
    }
}