namespace AdventOfCode.Puzzles.Days._03;

internal record PartNumber(string Number, int Value, IList<(int X, int Y)> Positions)
{
    public bool IsValid(IList<string> lines)
    {
        return Positions.SelectMany(Neighbours).Any(position => IsPart(lines, position.X, position.Y));
    }

    public (int X, int Y)? GearPosition(IList<string> lines)
    {
        var gears = Positions.SelectMany(Neighbours)
            .Where(position => IsPart(lines, position.X, position.Y, '*'))
            .ToList();
        if (gears.Any())
        {
            return gears.First();
        }

        return null;
    }

    private static bool IsPart(IList<string> lines, int x, int y, char? expected = null)
    {
        if (y < 0 || y >= lines.Count || x < 0 || x >= lines[0].Length)
        {
            return false;
        }

        var character = lines.Skip(y).First().Skip(x).First();
        if (expected == null)
        {
            return !char.IsDigit(character) && character != '.';
        }

        return character == expected;
    }

    private static IEnumerable<(int X, int Y)> Neighbours((int X, int Y) position)
    {
        yield return (position.X - 1, position.Y - 1);
        yield return (position.X - 1, position.Y);
        yield return (position.X - 1, position.Y + 1);
        yield return (position.X, position.Y - 1);
        yield return (position.X, position.Y + 1);
        yield return (position.X + 1, position.Y - 1);
        yield return (position.X + 1, position.Y);
        yield return (position.X + 1, position.Y + 1);
    }
}

internal static class MachineSchemeReader
{
    public static IEnumerable<PartNumber> FindPartNumbers(IList<string> lines)
    {
        var parts = new List<PartNumber>();

        for (var y = 0; y < lines.Count; y++)
        {
            var partNumber = string.Empty;
            var neighbours = new List<(int X, int Y)>();

            for (var x = 0; x < lines[y].Length; x++)
            {
                if (char.IsDigit(lines[y][x]))
                {
                    partNumber += lines[y][x];
                    neighbours.Add((x, y));
                }
                else
                {
                    if (partNumber != string.Empty)
                    {
                        parts.Add(new PartNumber(partNumber, int.Parse(partNumber), neighbours));
                    }

                    partNumber = string.Empty;
                    neighbours = new List<(int X, int Y)>();
                }
            }

            if (partNumber != string.Empty)
            {
                parts.Add(new PartNumber(partNumber, int.Parse(partNumber), neighbours));
            }
        }

        return parts;
    }
    
    public static IEnumerable<Part> FindParts(IEnumerable<string> lines)
    {
        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var character in line)
            {
                if (!char.IsDigit(character) && character != '.')
                {
                    yield return new Part(character, x, y);
                }

                x++;
            }
                
            y++;
        }
    }

    private static IList<(int X, int Y)> Adjacent = new[]
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 0),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1),
    };
    
    public static IEnumerable<int> FindPartNumbers(Part part, IList<string> lines)
    {
        var adjacents = Adjacent.Where(adj => IsNumber(lines, part.X + adj.X, part.Y + adj.Y));
        foreach (var adjacent in adjacents)
        {
            var line = lines.Skip(part.Y + adjacent.Y).First();
            var numberChars = new List<char> { line[part.X + adjacent.X] };

            var next = 1;
            while (part.X + adjacent.X + next < line.Length)
            {
                var character = line[part.X + adjacent.X + next];
                if (char.IsDigit(character))
                {
                    numberChars.Add(character);
                }
                else
                {
                    break;
                }

                next++;
            }

            var previous = -1;
            while (part.X + adjacent.X + previous >= 0)
            {
                var character = line[part.X + adjacent.X + previous];
                if (char.IsDigit(character))
                {
                    numberChars.Insert(0, character);
                }
                else
                {
                    break;
                }

                previous--;
            }

            var value = new string(numberChars.ToArray());
            yield return int.Parse(value);   
        }
    }

    private static bool IsNumber(IList<string> lines, int x, int y)
    {
        if (x < 0 || y < 0 || x >= lines[0].Length || y >= lines.Count)
        {
            return false;
        }

        var character = lines.Skip(y).First().Skip(x).First();
        return char.IsDigit(character);
    }
}