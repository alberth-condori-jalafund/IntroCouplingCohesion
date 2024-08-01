namespace Generics;

using System.Collections;

public class Regression<T> : IEnumerable<int> where T : IPivot, new()
{
    private readonly T _pivot;

    public Regression(int limit)
    {
        _pivot = new T();
        _pivot.Limit = limit;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _pivot;
    }

    IEnumerator IEnumerable.GetEnumerator() 
    { 
        return GetEnumerator();
    }
}
