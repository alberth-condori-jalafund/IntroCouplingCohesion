namespace OrderProcessing;

public class OrderService
{
  private readonly Inventory _inventory;
  private readonly PaymentService _paymentService;
  private readonly EmailService _emailService;
  private double TotalAmount;

  public OrderService(Inventory inventory, PaymentService paymentService, EmailService emailService)
  {
    _inventory = inventory;
    _paymentService = paymentService;
    _emailService = emailService;
  }

  public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
  {
    TotalAmount = 0;

    if (CheckItemsAvailability(items))
    {
      CalculateTotalAmount(items);

      ReserveItems(items);

      var order = CreateOrder(customer, items);

      SendOrderEmails(customer, order);
    }
  }

  private void CalculateTotalAmount(List<(string item, int quantity)> items)
  {
    foreach (var (item, quantity) in items)
    {
      TotalAmount += 10 * quantity; // Assume each item costs 10 per unit
    }
  }

  private bool CheckItemsAvailability(List<(string item, int quantity)> items)
  {
    foreach (var (item, quantity) in items)
    {
      if (!_inventory.CheckItemAvailability(item, quantity))
      {
        Console.WriteLine($"Item {item} is not available in the requested quantity.");
        return false;
      }
    }
    return true;
  }

  private void ReserveItems(List<(string item, int quantity)> items)
  {
    foreach (var (item, quantity) in items)
    {
      _inventory.ReserveItem(item, quantity);
    }
  }

  private void SendOrderEmails(Customer customer, Order order)
  {
    if (_paymentService.ProcessPayment(customer, TotalAmount))
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

  private Order CreateOrder(Customer customer, List<(string item, int quantity)> items)
  {
    return new Order
    {
      Customer = customer,
      Items = new List<string>(items.ConvertAll(i => i.item)),
      TotalAmount = TotalAmount
    };
  }
}
