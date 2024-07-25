namespace OrderProcessing;

public class EmailService
{
  public void SendOrderConfirmationEmail(Customer customer, Order order)
  {
    Console.WriteLine($"Email sent to {customer.getName}: Order placed with total amount {order.TotalAmount}");
  }

  public void SendPaymentFailedEmail(Customer customer)
  {
    Console.WriteLine($"Email sent to {customer.getEmail}: Payment failed. Please try again.");
  }
}
