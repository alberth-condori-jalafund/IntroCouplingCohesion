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

    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    public string Email
    {
        get => _email;
        private set => _email = value;
    }

    public string Address
    {
        get => _address;
        private set => _address = value;
    }
}
