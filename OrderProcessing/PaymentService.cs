namespace OrderProcessing;

public class PaymentService
{
  public bool ProcessPayment(Customer customer, double amount)
  {
    Console.WriteLine($"Processing payment for {customer.Name} of amount {amount}");

    return true;
  }
}
