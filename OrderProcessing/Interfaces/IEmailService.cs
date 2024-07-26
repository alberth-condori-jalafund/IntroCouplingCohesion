namespace OrderProcessing;

public interface IEmailService 
{
  public void SendOrderConfirmationEmail(Customer customer, Order order);

  public void SendPaymentFailedEmail(Customer customer);
}