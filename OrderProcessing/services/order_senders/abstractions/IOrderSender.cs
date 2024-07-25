namespace OrderProcessing;

public interface IOrderSender<T> where T : AbstractItem
{
    public void SendMessage(Customer customer, string message);

    public void SendOrderConfirmation(Customer customer, Order<T> order);

    public void SendPaymentFailed(Customer customer);
}