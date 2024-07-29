namespace OopBasics;

public abstract class Parent
{
    public string Name { get; set; }

    public Parent(string name)
    {
        Name = name;
    }

    public void Method3()
    {
    }

    // Posibilidad de sobreescribir

    public virtual void Method1()
    {
        // Ya tiene algo
    }

    public abstract void Method2();
}

public class Child : Parent
{
    public Child(string name)
        : base(name) { }

    public override void Method2()
    {
        // Sobreescribo Method2
    }
}

public interface IEat
{
    void Lavarse();

    void Sentarse();

    void Comer();

    void Levantarse();
}

public class Kid : IEat
{
    public void Lavarse()
    {
        throw new NotImplementedException();
    }

    public void Sentarse()
    {
        throw new NotImplementedException();
    }

    public void Comer()
    {
        throw new NotImplementedException();
    }

    public void Levantarse()
    {
        throw new NotImplementedException();
    }
}

public class Program
{
    /*
     * Objeto => Instancia => Clase
     * Clase => Definir los comportamientos y caracteristicas de un / Descripcion de la realidad / Abstraccion => Objeto
     * 
     * WARNING: Se prefiere la composicion sobre la herencia
     * 
     * Herencia:
     *          Abstracta:
     *              1. clase es abstracta
     *              2. si el constructor esta definido debe ser como minimo protegido
     *              3. contiene como minimo un metodo abstracto
     *              
     *          Simple:
     *              1. tiene sentido instanciar en su CONTEXTO (una clase cualquiera sea debe tener sentido en su contexto)
     *              
     *          Interfaces:
     *              1. no hereda las vulnerabilidades o problemas de las clases padres
     *              2. el nivel de encapsulamiento depende de la interfaz. Las clases que la implementan no pueden tener un nivel mas alto
     *              3. un clase puede implementar multiples interfaces
     *              4. Define el QUE mientras que la clase que la implementa define el COMO
     *              
     * Polimorfismo:
     */

    static void Main()
    {
        var nombre = "Alberth";
        var instance = new Child(nombre);
    }
}
