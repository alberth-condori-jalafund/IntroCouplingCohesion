namespace OrderProcessing;

public class Inventory
{
  private readonly Dictionary<string, int> _stock;

  public Inventory(){
    _stock = [];
  }

  public Inventory(Dictionary<string, int> initialStock)
  {
    _stock = initialStock;
  }

  public bool CheckItemAvailability(string item, int quantity)
  {
    return CheckIfItemExists(item) && _stock[item] >= quantity;
  }

  private bool CheckIfItemExists(string item){
    return _stock.ContainsKey(item);
  }

  public void ReserveItem(string item, int quantity)
  {
    if (CheckIfItemExists(item))
    {
      _stock[item] -= quantity;
      Console.WriteLine($"Item {item} reserved: {quantity} units.");
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
  }
}
