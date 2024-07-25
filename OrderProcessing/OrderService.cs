namespace OrderProcessing;

public class OrderService
{
  private const float ItemCost = 10;
  private readonly Inventory _inventory;
  
  private readonly PaymentService _paymentService;
  
  private readonly EmailService _emailService;

  public OrderService()
  {
    _inventory = new Inventory();
    _paymentService = new PaymentService();
    _emailService = new EmailService();
  }

public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
  {
    if (CheckAndReserveItems(items, out double totalAmount))
    {
      var order = CreateOrder(customer, items, totalAmount);

      if (_paymentService.ProcessPayment(customer, totalAmount))
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
  }

  private bool CheckAndReserveItems(List<(string item, int quantity)> items, out double totalAmount)
  {
    totalAmount = 0;
    bool allItemsAvailable = true;

    foreach (var (item, quantity) in items)
    {
      if (_inventory.CheckItemAvailability(item, quantity))
      {
        _inventory.ReserveItem(item, quantity);
        totalAmount += ItemCost * quantity; // Assume each item costs 10 per unit
      }
      else
      {
        allItemsAvailable = false;
        Console.WriteLine($"Item {item} is not available in the requested quantity.");
      }
    }

    return allItemsAvailable;
  }

  private Order CreateOrder(Customer customer, List<(string item, int quantity)> items, double totalAmount)
  {
    return new Order
    {
      Customer = customer,
      Items = new List<string>(items.ConvertAll(i => i.item)),
      TotalAmount = totalAmount
    };
  }

}
