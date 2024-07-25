namespace OrderProcessing;

public interface IRepository<T> where T : EntityBase
{
    public void AddItem(T item);

    public bool ContainsItem(T item);

    public T GetItemById(Guid itemId);

    public void UpdateAllItem(T item);

}