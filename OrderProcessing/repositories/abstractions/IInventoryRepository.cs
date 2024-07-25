namespace OrderProcessing;

public interface IInventoryRepository<T> : IRepository<T> where T : AbstractItem
{
    public void IncreaseStock(T item, int quantity);

    public void DecreaseStock(T item, int quantity);

    public bool IsTheItemAvailable(T item, int quantity);
}