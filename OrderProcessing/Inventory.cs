namespace OrderProcessing;

public class Inventory
{
  private Dictionary<Item, int> _stock = [];

  public bool CheckItemAvailability(Item item, int quantity)
  {
    return _stock.ContainsKey(item) && _stock[item] >= quantity;
  }

  public void ReserveItem(Item item, int quantity)
  {
    if (CheckItemAvailability(item, quantity))
    {
      _stock[item] -= quantity;
      Console.WriteLine($"Item {item.Name} reserved: {quantity} units.");
    }
  }

  public void RestockItem(Item item, int quantity)
  {
    if (_stock.ContainsKey(item))
    {
      _stock[item] += quantity;
    }
    else
    {
      _stock[item] = quantity;
    }
  }

  public void AddItem(Item item, int quantity)
  {
    _stock.Add(item, quantity);
  }
}
