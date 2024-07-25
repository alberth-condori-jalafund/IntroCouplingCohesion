namespace OrderProcessing;

public class InventoryRepository<T> : AbstractBaseRepository<T>, IInventoryRepository<T> where T : AbstractItem
{
    public void DecreaseStock(T item, int quantity)
    {
        Data[item.Id].StockQuantity -= quantity;
    }

    public void IncreaseStock(T item, int quantity)
    {
        Data[item.Id].StockQuantity += quantity;
    }

    public bool IsTheItemAvailable(T item, int quantity)
    {
        if (ContainsItem(item))
        {
            return GetItemById(item.Id).StockQuantity >= quantity;
        }

        return false;
    }
}