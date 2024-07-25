namespace OrderProcessing;

public abstract class AbstractBaseRepository<T> : IRepository<T> where T : EntityBase
{

    public Dictionary<Guid, T> Data { get; set; }

    public AbstractBaseRepository()
    {
        Data = new Dictionary<Guid, T>();
    }

    public void AddItem(T item)
    {
        Data.Add(item.Id, item);
    }

    public void AddItems(params T[] items)
    {
        foreach (T item in items)
        {
            AddItem(item);
        }
    }

    public bool ContainsItem(T item)
    {
        return Data.ContainsKey(item.Id);
    }

    public T GetItemById(Guid itemId)
    {
        return Data[itemId];
    }

    public void UpdateAllItem(T item)
    {
        Data[item.Id] = item;
    }
}