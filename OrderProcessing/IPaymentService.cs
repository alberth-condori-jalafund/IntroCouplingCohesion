namespace OrderProcessing;

public interface IPaymentService
{
  bool ProcessPayment(Customer customer, double amount);
}
