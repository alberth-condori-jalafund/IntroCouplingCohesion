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
    if (DataValidator.ValidatePositiveNumbers(quantity) == false)
    {
      Console.WriteLine("Invalid quantity number");
      return false;
    }
    return _stock.ContainsKey(item) && _stock[item] >= quantity;
  }

  public void ReserveItem(string item, int quantity)
  {
    _stock[item] -= quantity;
    Console.WriteLine($"Item {item} reserved: {quantity} units.");
  }

  public void RestockItem(string item, int quantity)
  {
    if (DataValidator.ValidatePositiveNumbers(quantity))
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
  }
}
