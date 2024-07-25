namespace OrderProcessing;

public class Order<T> where T : AbstractItem
{
  public Customer Customer { get; set; }
  public List<T> Items { get; set; }
  public double TotalAmount { get; set; }
  public PaymentStatus PaymentStatus { get; set; }
}
