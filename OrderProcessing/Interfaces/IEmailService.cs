namespace OrderProcessing.Interfaces
{
    using OrderProcessing.Models;
    
    public interface IEmailService
    {
        void SendOrderConfirmationEmail(Customer customer, Order order);
        void SendPaymentFailedEmail(Customer customer);
    }
}