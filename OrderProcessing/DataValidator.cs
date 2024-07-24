namespace OrderProcessing;

using System.Net.Mail;

public class DataValidator
{
    public static bool ValidatePositiveNumbers(int number)
    {
        if (number < 0)
        {
            Console.WriteLine("Invalida number");
            return false;
        }
        return true;

    }

    public static void ValidateEmail(string email)
    {
        try
        {
            email = new MailAddress(email).Address;
        }
        catch (FormatException)
        {
            throw new FormatException();
        }
    }
}
