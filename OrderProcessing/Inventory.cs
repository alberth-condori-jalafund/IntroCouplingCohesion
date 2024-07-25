namespace OrderProcessing;

public class Inventory : IInventoryService
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

  public bool TryReserveItem(RequestOrderItem item)
  {
    var itemAvailability = CheckItemAvailability(item);

    if (itemAvailability)
    {
      var itemToTake = _stock.FirstOrDefault(stockItem => stockItem.ItemName == item.ItemName);
      itemToTake.Quantity -= item.Quantity;
      Console.WriteLine($"Item {itemToTake.ItemName} reserved: {item.Quantity} units.");
    }
    else
    {
      Console.WriteLine($"Item {item} is not available in the requested quantity.");
    }

    return itemAvailability;
  }

  public bool CheckItemAvailability(RequestOrderItem item)
  {
    var itemToCheck = _stock.FirstOrDefault(stockItem => stockItem.ItemName == item.ItemName);

    if (itemToCheck == null)
    {
      throw new ArgumentException("The item doesn't exists.");
    }
    
    return itemToCheck.Quantity >= item.Quantity;
  }
}
