namespace OrderProcessing;

public class OrderService
{
  private Inventory _inventory;
  
  private PaymentService _paymentService;
  
  private EmailService _emailService;

  public OrderService(Inventory inventory)
  {
    _inventory = inventory;
    _paymentService = new();
    _emailService = new();
  }

  public void ProcessOrder(Customer customer, List<(Item item, int quantity)> items)
  {
    var order = new Order(customer);

    foreach (var (item, quantity) in items)
    {
      if (!AddItemToOrder(order, item, quantity))
      {
        Console.WriteLine($"Item {item.Name} is not available in the requested quantity.");
        return;
      }
    }

    ReserveItems(items);
    order.CalculateTotalAmount();

    if (_paymentService.ProcessPayment(customer, order.TotalAmount))
      {
        order.PaymentStatus = "Paid";
        _emailService.SendOrderConfirmationEmail(customer, order);
      }
      else
      {
        order.PaymentStatus = "Payment Failed";
        _emailService.SendPaymentFailedEmail(customer);
      }
  }

  private bool AddItemToOrder(Order order, Item item, int quantity)
  {
    if(_inventory.CheckItemAvailability(item, quantity))
    {
      order.Items.Add((item,quantity));
      return true;
    }
    return false;
  }

  private void ReserveItems(List<(Item item, int quantity)> items)
  {
    foreach(var (item, quantity) in items)
    {
      _inventory.ReserveItem(item, quantity);
    }
  }
}
