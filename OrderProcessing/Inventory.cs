namespace OrderProcessing;

public class Inventory
{
  public Dictionary<string, int> stock = new Dictionary<string, int>
        {
            { "Item1", 10 },
            { "Item2", 5 },
            { "Item3", 20 }
        };

  public bool CheckItemAvailability(string item, int quantity)
  {
    return stock.ContainsKey(item) && stock[item] >= quantity;
  }

  public void ReserveItem(string item, int quantity)
  {
    if (stock.ContainsKey(item) && CheckItemAvailability(item, quantity))
    {
      stock[item] -= quantity;
      Console.WriteLine($"Item: {item} reserved: {quantity} units.");
    }
  }

  public void RestockItem(string item, int quantity)
  {
    if (stock.ContainsKey(item))
    {
      stock[item] += quantity;
    }
    else
    {
      stock[item] = quantity;
    }
  }
}
