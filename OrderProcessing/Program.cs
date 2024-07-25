namespace OrderProcessing;

public class Program
{
  public static void Main()
  {
    // High cohesion and low coupling
    // Modularization
    var paymentService = new GooglePaymentService();
    var emailService = new TwilioEmailService();
    var customer = new Customer { Name = "Alberth Condori", Email = "alberth.condori@example.com", Address = "123 Main St" };
    var items = new List<RequestOrderItem>
    {
      new()
      {
        ItemName = "Item1",
        Quantity = 3
      },
      new()
      {
        ItemName = "Item2",
        Quantity = 1
      },
      new()
      {
        ItemName = "Item3",
        Quantity = 2
      }
    };
    var orderService = new OrderService(paymentService, emailService);
    orderService.ProcessOrder(customer, items);
  }
}
