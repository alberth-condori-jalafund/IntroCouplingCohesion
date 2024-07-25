namespace OrderProcessing.Models;

public class Customer
{
  public string Name { get; set; }
  
  public string Email { get; set; }
  
  public string Address { get; set; }

  public Customer(string Name, string Email, string Address)
  {
    this.Name = Name;
    this.Email = Email;
    this.Address = Address;
  }
}
