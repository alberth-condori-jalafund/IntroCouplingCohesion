namespace OrderProcessing
{
    public class Inventory
    {
        private readonly Dictionary<string, int> _stock;

        public Inventory(Dictionary<string, int> initialStock)
        {
            _stock = new Dictionary<string, int>(initialStock);
        }

        public bool CheckItemAvailability(string item, int quantity)
        {
            return _stock.TryGetValue(item, out var availableQuantity) && availableQuantity >= quantity;
        }

        public bool ReserveItem(string item, int quantity)
        {
            if (CheckItemAvailability(item, quantity))
            {
                _stock[item] -= quantity;
                Console.WriteLine($"Item {item} reserved: {quantity} units.");
                return true;
            }
            else
            {
                Console.WriteLine($"Item {item} could not be reserved. Insufficient stock.");
                return false;
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
}

