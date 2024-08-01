namespace Generics;

/// <summary>
/// Generics:
///         Gestione el tipo de datos deacuerdo a contexto del tipo de dato.
///         
///         Existen genericos cerrados al contexto y abiertos al cualquier tipo de dato:
///             Los abiertos no realizan operaciones alrededor del tipo y la usan como recurso
///             Los cerrados son aquellos que podrian operar en base al contexto del dato.
/// </summary>

public class Test : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public class RandomClass<T, TK>
    where T : IDisposable, new()
    where TK : class
{
    public void Method(T instance)
    {
        instance.Dispose();
    }
}

public class Program
{
    public static void Main()
    {
        //var test = new Test();
        //Test test1;
        //var randonClass = new RandomClass<Test, Test>();

        var limit = 10;
        var fibo = new Regression<PivotFibonacci>(limit);

        var pairs = fibo.Where(n => n % 2 == 0);

        foreach (var fibonacci in pairs)
        {
            Console.WriteLine(fibonacci.ToString());
        }
    }
}
