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
    var (areAllItemsAvailable, totalAmount) = _inventory.TryReserveItems(items);

    if (areAllItemsAvailable)
    {
      var order = new Order
      {
        Customer = customer,
        Items = new List<string>(items.ConvertAll(item => item.ItemName)),
        TotalAmount = totalAmount
      };

      SendOrderProtocols(customer, order, totalAmount);
    }
  }

  private void SendOrderProtocols(Customer customer, Order order, decimal totalAmount)
  {
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
