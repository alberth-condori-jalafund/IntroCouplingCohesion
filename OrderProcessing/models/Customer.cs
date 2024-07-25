namespace OrderProcessing;

public class Customer
{
  public string Name { get; set; }
  
  public string Email { get; set; }
  
  public string Address { get; set; }

  public Customer( string name, string email, string address )
  {
    Name = name;
    Email = email;
    Address = address;
  }
}
