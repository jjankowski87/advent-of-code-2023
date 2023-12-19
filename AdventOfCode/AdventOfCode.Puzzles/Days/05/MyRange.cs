namespace AdventOfCode.Puzzles.Days._05;

internal record RangeMapping(MyRange SourceRange, long DestinationRangeStart)
{
    public MyRange MapToDestinationRange(MyRange rangeToMap)
    {
        return new MyRange(rangeToMap.Start - SourceRange.Start + DestinationRangeStart, rangeToMap.Length);
    }
}

internal record MyRange(long Start, long Length)
{
    public long End => Start + Length - 1;

    public static MyRange FromStartEnd(long start, long end) => new MyRange(start, end - start + 1);
    
    public MyRange? Cross(MyRange other)
    {
        // starts before
        if (other.Start > End)
        {
            return null;
        }

        // starts after
        if (Start > other.End)
        {
            return null;
        }

        var start = Math.Max(Start, other.Start);
        var end = Math.Min(End, other.End);

        return FromStartEnd(start, end);
    }
}