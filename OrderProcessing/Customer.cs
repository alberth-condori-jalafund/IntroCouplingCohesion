namespace OrderProcessing;

public class Customer
{
  private string _name;
  private string _email;
  private string _address;

  public Customer(string name, string email, string address)
  {
    _name = name;
    _email = email;
    _address = address;
  }

  public string getName()
  {
    return _name;
  }
  public string getEmail()
  {
    return _email;
  }
  public string getAddress()
  {
    return _address;
  }
}
