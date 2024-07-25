namespace OrderProcessing;

public class PaymentService
{
  public bool ProcessPayment(Customer customer, double amount)
  {
    Console.WriteLine($"Processing payment for {customer.getName} of amount {amount}");
    
    return true; // Assume payment is always successful
  }
}
