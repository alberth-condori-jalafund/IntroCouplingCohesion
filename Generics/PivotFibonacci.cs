namespace Generics;

using System.Collections;

public class PivotFibonacci : IPivot
{
    private int _index;
    private int _previous;

    public int Current { get; private set; }

    public int Limit { get; set; }

    object IEnumerator.Current => Current;

    public PivotFibonacci()
    {
        Current = 0;
        _index = -1;
        _previous = 1;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (_index < Limit)
        {
            int auxiliary = _previous;
            _previous = Current;
            Current += auxiliary;
            _index++;
        }

        return _index < Limit;
    }

    public void Reset()
    { }
}
