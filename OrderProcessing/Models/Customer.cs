namespace OrderProcessing.Models;

public class Customer
{
  public string Name { get; }
  public string Email { get; }
  public string Address { get; }

  public Customer(string name, string email, string address)
  {
    Name = name;
    Email = email;
    Address = address;
  }
}
