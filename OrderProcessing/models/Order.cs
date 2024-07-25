namespace OrderProcessing;

public class Order
{
  public Customer Customer { get; set; }
  
  public List<(Item,int)> Items { get; set; }
  
  public double TotalAmount { get; set; }
  
  public string PaymentStatus { get; set; }

  public Order(Customer customer)
  {
    Customer = customer;
    Items = [];
  }

  public void CalculateTotalAmount()
  {
    int totalAmount = 0;
    
    foreach(var (item, quantity) in Items)
    {
      totalAmount += item.Price *quantity;
    }

    TotalAmount = totalAmount;
  }
}
