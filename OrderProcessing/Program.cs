namespace OrderProcessing;

public class Program
{
  public static void Main()
  {
    // initialization of services
    SimpleItem item1 = new SimpleItem
    {
      Id = Guid.NewGuid(),
      Price = 10,
      StockQuantity = 10,
      ItemName = "Item1"
    };
    SimpleItem item2 = new SimpleItem
    {
      Id = Guid.NewGuid(),
      Price = 10,
      StockQuantity = 5,
      ItemName = "Item2"
    };
    SimpleItem item3 = new SimpleItem
    {
      Id = Guid.NewGuid(),
      Price = 10,
      StockQuantity = 20,
      ItemName = "Item3"
    };

    IFeedbackService feedbackService = new ConsoleFeedbackService();
    InventoryRepository<SimpleItem> repository = new();
    repository.AddItem(item1);
    repository.AddItem(item2);
    repository.AddItem(item3);
    SimplePaymentService paymentService = new(feedbackService);
    List<IOrderSender<SimpleItem>> senders = [new EmailOrderSender<SimpleItem>(feedbackService)];

    // customer sale
    Customer customer = new Customer
    {
      Name = "Alberth Condori",
      Email = "alberth.condori@example.com",
      Address = "123 Main St"
    };

    var items = new List<(SimpleItem, int)> {
          (item1, 2), (item2, 1), (item3, 1)
        };

    // processing sale
    var orderService = new OrderService<SimpleItem>(repository, paymentService, senders, feedbackService);
    orderService.ProcessOrder(customer, items);
  }
}
