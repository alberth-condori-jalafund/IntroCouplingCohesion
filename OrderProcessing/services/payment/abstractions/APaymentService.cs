namespace OrderProcessing;

public abstract class APaymentService
{
    public PaymentStatus PaymentStatus { get; protected set; }

    public abstract void ProcessPayment(Customer customer, double amount);

    public abstract bool WasSuccessfulPayment();
}