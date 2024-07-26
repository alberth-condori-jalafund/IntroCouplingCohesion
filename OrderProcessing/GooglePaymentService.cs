namespace OrderProcessing;

public class GooglePaymentService : IPaymentService
{
  public bool ProcessPayment(Customer customer, decimal amount)
  {
    Console.WriteLine($"Processing payment for {customer.Name} of amount {amount}");
    
    return true; // Assume payment is always successful
  }
}
