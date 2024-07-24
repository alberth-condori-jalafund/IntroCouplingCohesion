namespace OrderProcessing;

public class Order
{
  public Customer Customer { get; set; }
  
  public List<string> Items { get; set; }
  
  public double TotalAmount { get; set; }
  
  public string PaymentStatus { get; set; }
}
