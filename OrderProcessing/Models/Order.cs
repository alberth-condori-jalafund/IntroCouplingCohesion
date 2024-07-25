namespace OrderProcessing.Models;

public class Order
{
  public Customer Customer { get; set; }
  
  public List<string> Items { get; set; }
  
  public double TotalAmount { get; set; }
  
  public string PaymentStatus { get; set; }

  public Order(Customer customer, List<string> items, double totalAmount)
  {
    Customer = customer;
    Items = items;
    TotalAmount = totalAmount;
  }
}
