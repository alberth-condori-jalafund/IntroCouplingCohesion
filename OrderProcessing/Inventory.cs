namespace OrderProcessing;

public class Inventory
{
  private Dictionary<string, int> _stock = new Dictionary<string, int>
        {
            { "Item1", 10 },
            { "Item2", 5 },
            { "Item3", 20 }
        };

  public bool CheckItemAvailability(string item, int quantity)
  {
    return _stock.ContainsKey(item) && _stock[item] >= quantity;
  }

  public void ReserveItem(string item, int quantity)
  {
    if (CheckItemAvailability(item, quantity))
    {
      _stock[item] -= quantity;
      Console.WriteLine($"Item {item} reserved: {quantity} units.");
    }
  }

  // delete RestockItem method
}
