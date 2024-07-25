namespace OrderProcessing;

public class InventoryHandler<T> where T : AbstractItem
{
  private IInventoryRepository<T> _inventory;
  private IFeedbackService _feedbackService;

  public InventoryHandler(IInventoryRepository<T> inventory, IFeedbackService feedbackService)
  {
    _inventory = inventory;
    _feedbackService = feedbackService;
  }

  public void ReserveItem(T item, int quantity)
  {
    if (_inventory.ContainsItem(item))
    {
      _inventory.DecreaseStock(item, quantity);
      _feedbackService.SendFeedback($"Item {item} reserved: {quantity} units.");
    }
    else
    {
      _feedbackService.SendFeedback($"Item {item} reserved: {quantity} units.");
    }
  }

  public bool RestockItemIfExists(T item, int quantity)
  {
    if (_inventory.ContainsItem(item))
    {
      _inventory.IncreaseStock(item, quantity);
      _feedbackService.SendFeedback($"Item {item} increased: {quantity} units.");
      return true;
    }

    return false;
  }

  public void RestockItemOrCreate(T item, int quantity)
  {
    bool wasMade = RestockItemIfExists(item, quantity);
    if (!wasMade)
    {
      item.StockQuantity = quantity;
      _inventory.AddItem(item);
      _feedbackService.SendFeedback($"Item {item} increased: {quantity} units.");
    }
  }

}
