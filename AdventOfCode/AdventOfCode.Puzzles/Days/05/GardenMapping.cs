namespace AdventOfCode.Puzzles.Days._05;

internal class GardenMapping
{
    private readonly IList<SingleMapping> _mappings;

    private readonly IList<RangeMapping> _rangeMappings;

    public GardenMapping(string source, string destination, IEnumerable<SingleMapping> mappings)
    {
        Source = source;
        Destination = destination;
        _mappings = mappings.OrderBy(x => x.SourceRangeStart).ToList();
        _rangeMappings = BuildRanges(_mappings);
    }

    public string Source { get; }

    public string Destination { get; }

    public long Map(long source)
    {
        foreach (var mapping in _mappings)
        {
            if (source >= mapping.SourceRangeStart && source < mapping.SourceRangeStart + mapping.RangeLength)
            {
                var diff = source - mapping.SourceRangeStart;
                return mapping.DestinationRangeStart + diff;
            }
        }

        return source;
    }

    public IEnumerable<MyRange> MapRanges(MyRange sourceRange)
    {
        foreach (var rangeMapping in _rangeMappings)
        {
            var cross = sourceRange.Cross(rangeMapping.SourceRange);
            if (cross != null)
            {
                yield return rangeMapping.MapToDestinationRange(cross);
            }
        }
    }

    private static IList<RangeMapping> BuildRanges(IList<SingleMapping> mappings)
    {
        var result = new List<RangeMapping>();
        if (mappings[0].SourceRangeStart > 0)
        {
            result.Add(new RangeMapping(MyRange.FromStartEnd(0, mappings[0].SourceRangeStart - 1), 0));
        }

        for (var i = 0; i < mappings.Count; i++)
        {
            var mapping = mappings[i];
            if (i > 0)
            {
                var previousRange = result.Last().SourceRange;
                if (mapping.SourceRangeStart > previousRange.End + 1)
                {
                    result.Add(new RangeMapping(MyRange.FromStartEnd(previousRange.End + 1, mapping.SourceRangeStart - 1), previousRange.End + 1));
                }
            }

            result.Add(new RangeMapping(new MyRange(mapping.SourceRangeStart, mapping.RangeLength), mapping.DestinationRangeStart));
        }

        var lastRange = result.Last();
        result.Add(new RangeMapping(MyRange.FromStartEnd(lastRange.SourceRange.End + 1, long.MaxValue), lastRange.SourceRange.End + 1));

        return result;
    }
}