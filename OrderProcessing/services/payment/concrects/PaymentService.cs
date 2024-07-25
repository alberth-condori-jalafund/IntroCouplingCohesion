namespace OrderProcessing;

public class SimplePaymentService : APaymentService
{
  private IFeedbackService _feedbackService;

  public SimplePaymentService(IFeedbackService feedbackService) {
    _feedbackService = feedbackService;
  }

  public override void ProcessPayment(Customer customer, double amount)
  {
    _feedbackService.SendFeedback($"Processing payment for {customer.Name} of amount {amount}");
    PaymentStatus = PaymentStatus.SUCCESSFUL;
  }

  public override bool WasSuccessfulPayment()
  {
    return PaymentStatus == PaymentStatus.SUCCESSFUL;
  }
}
