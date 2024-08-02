namespace Mix;

public class Program
{
    public static int Addition(int a, int b)
    {
        return a + b;
    }

    public static int Addition(int a, int b, int c)
    {
        return a + b + c;
    }

    public static int Addition(bool flat, params int[] numbers)
    {
        var response = 0;

        foreach (int n in numbers)
        {
            response += n;
        }

        return response;
    }

    public static void Main()
    {
        // Extension methods
        int number = 10;
        number.IsPotency();
        number.IsPotency(2);
        number.PrintLiteral();

        // indexers
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        numbers[1] = 20;

        var students = new Indexer();

        students[0] = new Student();
        students["Salinas"] = new Student();
        students[Guid.NewGuid()] = new Student();

        // params variables
        Addition(1, 2);


    }
}
