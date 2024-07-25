﻿namespace OrderProcessing;

public class Inventory
{
    private readonly Dictionary<string, int> _stock = new()
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
        if (_stock.ContainsKey(item))
        {
            _stock[item] -= quantity;
            Console.WriteLine($"Item {item} reserved: {quantity} units.");
        }
    }

    public void RestockItem(string item, int quantity)
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
