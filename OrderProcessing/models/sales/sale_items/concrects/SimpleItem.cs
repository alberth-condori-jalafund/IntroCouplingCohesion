namespace OrderProcessing;

public class SimpleItem : AbstractItem
{
    public string ItemName { get; set; }

    public override string ToString()
    {
        return ItemName;
    }
}