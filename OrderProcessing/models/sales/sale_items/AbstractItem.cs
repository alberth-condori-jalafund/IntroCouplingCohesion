namespace OrderProcessing;

public abstract class AbstractItem : EntityBase
{
    public int StockQuantity { get; set; }
    public int Price { get; set; }
}