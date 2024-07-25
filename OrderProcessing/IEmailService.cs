namespace OrderProcessing;

public interface IEmailService
{
  void SendOrderConfirmationEmail(Customer customer, Order order);

  void SendPaymentFailedEmail(Customer customer);
}
