namespace CompositionVsInheritance;

public class A
{
    public void Foo()
    {
    }

    //public void Bar()
    //{
    //    Console.WriteLine("from parent");
    //}
}

public class B : A
{
    public void Bar()
    {
        Console.WriteLine("from child");
    }
}

public interface IC
{
    void Foo();

    int Bar();
}

public class C : IC
{
    public void Foo()
    {
    }

    public int Bar()
    { 
        return 0; 
    }
}

public class D
{
    private readonly IC _c;

    public D()
    {
        _c = new C();
    }

    public void Bar()
    {
        _c.Bar();
        _c.Foo();
    }
}

/// <summary>
/// Composicion:
///         tanto la clase base como la clase derivadas deben tener sentido en su contexto (estructuras con clases abstractas son dificiles de definir como composicion)
///         perdemos funcion polimorifca
///         la composición tiende a crecer horizontalmente
///         la composición suele interpretarse como una relación "Has A"
///         limitamos la exposición de los metodos y propiedades del objeto (explicitamente)
///         realizar mantenimiento en estructuras compuestas suele ser más sencillo
///         tiene mayor grado y mejor manejo de encapsulamiento
///         podemos cambiar el uso de las clase base en tiempo de ejecución
///         composición si o si tenemos que reimplementar los metodos derivados de las interfaces
/// Herencia:
///         culaquier cambio en la clase base crea un efecto en las clases derivadas
///         la herencia tiende a crecer verticalmente
///         el código suele ser acoplado
///         la herencia suele interpretarse como una relación "Is A"
///         no solo se extendemos caracteristicas sino también las vulnerabilidades (implicitamente)
///         la reutilización de código es más efectiva y sencilla en estructuras heredadas
///         una vez instanciada a clase derivada nos atamos a la clase base
///         si o si creamos una imagen de la clase base
///         podemos reutilizar mucho codigo
/// </summary>

public class Program
{
    public static void Something(A a)
    {
    }

    public static void Something2(B b) { }


    static void Main()
    {
        var b = new B();
        b.Bar();
    }
}
