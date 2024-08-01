namespace Generics;

public interface IPivot : IEnumerator<int>
{
    int Limit { get; set; }
}
