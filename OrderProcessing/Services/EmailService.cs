namespace OrderProcessing.Services;

using OrderProcessing.Models;
using OrderProcessing.Interfaces;

public class EmailService : IEmailService
{
  public void SendOrderConfirmationEmail(Customer customer, Order order)
  {
    Console.WriteLine($"Email sent to {customer.Email}: Order placed with total amount {order.TotalAmount}");
  }

  public void SendPaymentFailedEmail(Customer customer)
  {
    Console.WriteLine($"Email sent to {customer.Email}: Payment failed. Please try again.");
  }
}
