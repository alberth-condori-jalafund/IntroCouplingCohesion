namespace OrderProcessing;

public interface IPaymentService 
{
    public bool ProcessPayment(Customer customer, double amount);
}