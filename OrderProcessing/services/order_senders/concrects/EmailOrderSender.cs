namespace OrderProcessing;

public class EmailOrderSender<T> : IOrderSender<T> where T : AbstractItem
{

  private IFeedbackService _feedbackService;

  public EmailOrderSender(IFeedbackService feedbackService)
  {
    _feedbackService = feedbackService;
  }

  public void SendMessage(Customer customer, string message) {
    // TODO: Implementation to send message by Email
    _feedbackService.SendFeedback($"Email sent to {customer.Email}: {message}");
  }

  public void SendOrderConfirmation(Customer customer, Order<T> order)
  {
    // TODO: Implementation to send order confirmation by Email
    _feedbackService.SendFeedback($"Email sent to {customer.Email}: Order placed with total amount {order.TotalAmount}");
  }

  public void SendPaymentFailed(Customer customer)
  {
    // TODO: Implementation to send failed payment by Email
    _feedbackService.SendFeedback($"Email sent to {customer.Email}: Payment failed. Please try again.");
  }
}
