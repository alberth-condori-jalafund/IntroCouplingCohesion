namespace OrderProcessing.Interfaces;
using OrderProcessing.Models;

public interface IPaymentService
{
    public bool ProcessPayment(Customer customer, double amount);
}
