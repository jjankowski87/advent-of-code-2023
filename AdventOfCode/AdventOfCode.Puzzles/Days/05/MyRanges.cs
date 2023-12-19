namespace AdventOfCode.Puzzles.Days._05;

internal class MyRanges
{
    private readonly IList<MyRange> _ranges;

    public MyRanges(MyRange range)
    {
        _ranges = new List<MyRange> { range };
    }

    public MyRanges(IEnumerable<MyRange> ranges)
    {
        _ranges = ranges.OrderBy(x => x.Start).ToList();
    }

    public IEnumerable<MyRange> Items => _ranges;

    public long GetLowestValue()
    {
        return _ranges.Select(x => x.Start).Min();
    }
}