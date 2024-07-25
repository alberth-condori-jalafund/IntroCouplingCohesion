namespace OrderProcessing;

public class OrderService
{
  private readonly Inventory _inventory;

  private readonly PaymentService _paymentService;

  private readonly EmailService _emailService;

  public OrderService(Inventory inventory, PaymentService paymentService, EmailService emailService)
  {
    _inventory = inventory;
    _paymentService = paymentService;
    _emailService = emailService;
  }

  public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
  {
    if (!CheckItemsAvailability(items))
    {
      return;
    }

    ReserveItems(items);
    double totalAmount = CalculateTotalAmount(items);
    var order = CreateOrder(customer, items, totalAmount);

    if (ProcessPayment(customer, totalAmount))
    {
      order.PaymentStatus = "Paid";
      SendOrderConfirmationEmail(customer, order);
    }
    else
    {
      order.PaymentStatus = "Payment Failed";
      SendPaymentFailedEmail(customer);
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

  private double CalculateTotalAmount(List<(string item, int quantity)> items)
  {
    double totalAmount = 0;
    foreach (var (item, quantity) in items)
    {
      totalAmount += 10 * quantity; // Assume each item costs 10 per unit
    }
    return totalAmount;
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

  private bool ProcessPayment(Customer customer, double totalAmount)
  {
    return _paymentService.ProcessPayment(customer, totalAmount);
  }

  private void SendOrderConfirmationEmail(Customer customer, Order order)
  {
    _emailService.SendOrderConfirmationEmail(customer, order);
  }

  private void SendPaymentFailedEmail(Customer customer)
  {
    _emailService.SendPaymentFailedEmail(customer);
  }

}
