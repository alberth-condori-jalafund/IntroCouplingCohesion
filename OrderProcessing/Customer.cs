namespace OrderProcessing;

public class Customer
{
  public string Name { get; set; }

  public string Email { get; set; }

  public Customer(string name, string email)
  {
    this.Name = name;
    this.Email = email;
    DataValidator.ValidateEmail(email);
  }

}
