namespace OrderProcessing;

public class OrderService
{
  private readonly Inventory _inventory;
  
  private readonly IPaymentService _paymentService;
  
  private readonly IEmailService _emailService;

  public OrderService(IPaymentService paymentService, IEmailService emailService)
  {
    _inventory = new();
    _paymentService = paymentService;
    _emailService = emailService;
  }

  public void ProcessOrder(Customer customer, List<RequestOrderItem> items)
  {
    double totalAmount = 0;
    bool allItemsAvailable = true;

    foreach (var item in items)
    {
      allItemsAvailable &= _inventory.TryReserveItem(item);
    }

    if (allItemsAvailable)
    {
      var order = new Order
      {
        // Customer = customer,
        // Items = new List<string>(items.ConvertAll(i => i.item)),
        // TotalAmount = totalAmount
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
