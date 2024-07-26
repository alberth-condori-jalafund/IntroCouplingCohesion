namespace OrderProcessing;

public class Inventory
{
  private readonly List<StockOrderItem> _stock =
  [
    new()
    {
      ItemName = "Item1",
      Quantity = 10,
      UnitPrice = 12
    },
    new()
    {
      ItemName = "Item2",
      Quantity = 20,
      UnitPrice = 24
    },
    new()
    {
      ItemName = "Item3",
      Quantity = 30,
      UnitPrice = 48
    }
  ];

  public List<StockOrderItem> Stock { get => _stock; }

  public (bool areAllItemsAvailable, decimal totalAmount) TryReserveItems(List<RequestOrderItem> items)
  {
    var areAllItemsAvailable = true;
    decimal totalAmount = 0;

    foreach (var item in items)
    {
      var (isItemReserved, unitPrice) = TryReserveItem(item);

      if (isItemReserved) 
      {
        totalAmount += unitPrice;
      }
      else 
      {
        areAllItemsAvailable = false;
        totalAmount = 0;
        break;
      }
    }

    return (areAllItemsAvailable, totalAmount);
  }

  public (bool isItemReserved, decimal unitPrice) TryReserveItem(RequestOrderItem item)
  {
    var isItemReserved = false;
    decimal unitPrice = 0;

    if (TryGetStockOrder(item, out var itemToTake))
    {
      isItemReserved = true;
      unitPrice = itemToTake.UnitPrice;
      itemToTake.Quantity -= item.Quantity;
      Console.WriteLine($"Item {itemToTake.ItemName} reserved: {item.Quantity} units.");
    }
    else
    {
      Console.WriteLine($"Item {item} is not available in the requested quantity.");
    }

    return (isItemReserved, unitPrice);
  }

  public bool TryGetStockOrder(RequestOrderItem item, out StockOrderItem stockOrderItem)
  {
    var isItemAvailable = false;
    var itemToCheck = _stock.FirstOrDefault(stockItem => stockItem.ItemName == item.ItemName);

    if (itemToCheck is not null) 
    {
      stockOrderItem = itemToCheck;
      isItemAvailable = itemToCheck.Quantity >= item.Quantity;
    }
    else 
    {
      stockOrderItem = null;
    }

    return isItemAvailable;
  }
}
