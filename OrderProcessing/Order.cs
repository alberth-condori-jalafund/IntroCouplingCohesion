namespace OrderProcessing;

public class Order
{
    public Customer Customer { get; set; }
    public List<(string ItemName, int Quantity)> Items { get; set; } = new();
    public double TotalAmount { get; set; }
    public string PaymentStatus { get; set; }
}
