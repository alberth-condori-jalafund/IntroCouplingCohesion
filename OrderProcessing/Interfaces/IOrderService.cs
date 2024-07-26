namespace OrderProcessing;

public interface IOrderService 
{
    public void ProcessOrder(Customer customer, List<(string item, int quantity)> items);

}