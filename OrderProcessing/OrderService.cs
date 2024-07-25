namespace OrderProcessing;

public class OrderService
{
  private Inventory _inventory;

  private PaymentService _paymentService;

  private EmailService _emailService;
  private double Unit_Cost = 10;

  public OrderService()
  {
    _inventory = new();
    _paymentService = new();
    _emailService = new();
  }
  private double OrderAmount( List<(string item, int quantity)> items)
  {
    double totalAmount = 0;
    foreach (var (item, quantity) in items)
    {
      if (_inventory.CheckItemAvailability(item, quantity))
      {
        _inventory.ReserveItem(item, quantity);
        totalAmount += Unit_Cost * quantity;
      }
      else
      {
        Console.WriteLine($"Item: {item} is not available in the requested quantity.");
        return 0;
      }
    }
    return totalAmount;
  }

  public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
  {
    var order = new Order
    {
      Customer = customer,
      Items = new List<string>(items.ConvertAll(i => i.item)),
      TotalAmount = OrderAmount(items)
    };

    if (_paymentService.ProcessPayment(customer, order.TotalAmount) && order.TotalAmount != 0)
    {
      order.PaymentStatus = "Paid";
      _emailService.SendOrderConfirmationEmail(customer, order);
    }
    else
    {
      order.PaymentStatus = "Payment Failed";
      _emailService.SendPaymentFailedEmail(customer, order);
    }
  }
}
