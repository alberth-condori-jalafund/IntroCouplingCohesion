using OrderProcessing.Interfaces;

namespace OrderProcessing.Services;

public class Inventory : IInventory
{
  private readonly Dictionary<string, int> _stock;

  public Inventory()
  {
    _stock = new Dictionary<string, int>();
  }

  public Inventory(Dictionary<string, int> initialStock)
  {
    _stock = initialStock;
  }

  public bool CheckItemAvailability(string item, int quantity)
  {
    return CheckIfItemExists(item) && _stock[item] >= quantity;
  }

  private bool CheckIfItemExists(string item)
  {
    return _stock.ContainsKey(item);
  }

  public void ReserveItem(string item, int quantity)
  {
    if (CheckIfItemExists(item))
    {
      _stock[item] -= quantity;
      Console.WriteLine($"Item {item} reserved: {quantity} units.");
    }
    else
    {
      Console.WriteLine($"Item {item} does not exist in inventory.");
    }
  }

  public void RestockItem(string item, int quantity)
  {
    if (CheckIfItemExists(item))
    {
      _stock[item] += quantity;
    }
    else
    {
      _stock[item] = quantity;
    }
    Console.WriteLine($"Item {item} restocked: {quantity} units.");
  }
}
