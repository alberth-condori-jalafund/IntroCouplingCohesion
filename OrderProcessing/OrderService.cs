namespace OrderProcessing;

public class OrderService
{
  private Inventory _inventory;
  
  private PaymentService _paymentService;
  
  private EmailService _emailService;

  public OrderService()
  {
    _inventory = new();
    _paymentService = new();
    _emailService = new();
  }

  public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
  {
    double totalAmount = 0;
    bool allItemsAvailable = true;

    foreach (var (item, quantity) in items)
    {
      if (_inventory.CheckItemAvailability(item, quantity))
      {
        _inventory.ReserveItem(item, quantity);
        totalAmount += 10 * quantity; // Assume each item costs 10 per unit
      }
      else
      {
        allItemsAvailable = false;
        Console.WriteLine($"Item {item} is not available in the requested quantity.");
      }
    }

    if (allItemsAvailable)
    {
      var order = new Order
      {
        Customer = customer,
        Items = new List<string>(items.ConvertAll(i => i.item)),
        TotalAmount = totalAmount
      };

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
}
