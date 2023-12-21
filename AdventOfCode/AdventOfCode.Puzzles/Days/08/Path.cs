using System.Collections;

namespace AdventOfCode.Puzzles.Days._08;

internal sealed class Path : IEnumerator<Direction>
{
    private readonly char[] _path;

    private int _index = 0;

    public Path(string path)
    {
        _path = path.ToArray();
    }

    public bool MoveNext()
    {
        _index++;
        if (_index >= _path.Length)
        {
            _index = 0;
        }

        return true;
    }

    public void Reset()
    {
        _index = 0;
    }

    public Direction Current => _path[_index] == 'L' ? Direction.Left : Direction.Right;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}