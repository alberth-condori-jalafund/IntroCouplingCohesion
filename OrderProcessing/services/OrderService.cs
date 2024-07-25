namespace OrderProcessing;

public class OrderService<T> where T : AbstractItem
{
  private double _totalAmount;
  private bool _allItemsAvailable;

  private InventoryHandler<T> _inventoryHandler;
  private IInventoryRepository<T> _inventoryRepository;
  private APaymentService _paymentService;
  private List<IOrderSender<T>> _orderSenders;
  private IFeedbackService _feedbackService;

  public OrderService(
    IInventoryRepository<T> inventoryRepository,
    APaymentService paymentService,
    List<IOrderSender<T>> orderSenders,
    IFeedbackService feedbackService
  )
  {
    _inventoryRepository = inventoryRepository;
    _inventoryHandler = new(inventoryRepository, feedbackService);
    _paymentService = paymentService;
    _orderSenders = orderSenders;
    _feedbackService = feedbackService;
  }

  public void ProcessOrder(Customer customer, List<(T item, int quantity)> items)
  {
    InitOrderValues();
    CalculateTotal(items);

    var order = CreateOrder(customer, items);
    _paymentService.ProcessPayment(customer, _totalAmount);
    order.PaymentStatus = _paymentService.PaymentStatus;
    SendFeedbackToTheUser(customer, order);
    if (!_allItemsAvailable)
    {
      SendMessage(customer, "Sorry, not all items were available.");
    }
  }

  private void InitOrderValues()
  {
    _totalAmount = 0;
    _allItemsAvailable = true;
  }

  private Order<T> CreateOrder(Customer customer, List<(T item, int quantity)> items)
  {
    return new Order<T>
    {
      Customer = customer,
      Items = new List<T>(items.ConvertAll(i => i.item)),
      TotalAmount = _totalAmount
    };
  }

  private void CalculateTotal(List<(T item, int quantity)> items)
  {
    foreach (var (item, quantity) in items)
    {
      if (_inventoryRepository.IsTheItemAvailable(item, quantity))
      {
        _inventoryHandler.ReserveItem(item, quantity);
        _totalAmount += item.Price * quantity;
      }
      else
      {
        _allItemsAvailable = false;
        _feedbackService.SendFeedback($"Item {item} is not available in the requested quantity.");
      }
    }
  }

  private void SendFeedbackToTheUser(Customer customer, Order<T> order)
  {
    if (_paymentService.WasSuccessfulPayment())
    {
      SendSuccessfulOrder(customer, order);
    }
    else
    {
      SendFailedOrder(customer);
    }
  }

  private void SendMessage(Customer customer, string message)
  {
    foreach (var sender in _orderSenders)
    {
      sender.SendMessage(customer, message);
    }
  }

  private void SendSuccessfulOrder(Customer customer, Order<T> order)
  {
    foreach (var sender in _orderSenders)
    {
      sender.SendOrderConfirmation(customer, order);
    }
  }

  private void SendFailedOrder(Customer customer)
  {
    foreach (var sender in _orderSenders)
    {
      sender.SendPaymentFailed(customer);
    }
  }
}
