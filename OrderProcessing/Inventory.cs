namespace OrderProcessing;

public class Inventory
{
    private Dictionary<string, int> _stock;

    public Inventory()
    {
        _stock = new Dictionary<string, int>
        {
            { "Item1", 10 },
            { "Item2", 5 },
            { "Item3", 20 }
        };
    }

    public bool CheckItemAvailability(string item, int quantity)
    {
        return _stock.ContainsKey(item) && _stock[item] >= quantity;
    }

    public void ReserveItem(string item, int quantity)
    {
        if (_stock.ContainsKey(item))
        {
            _stock[item] -= quantity;
            Console.WriteLine($"Item {item} reserved: {quantity} units.");
        }
    }
}
