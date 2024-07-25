namespace OrderProcessing;

public class ConsoleFeedbackService : IFeedbackService
{
    public void SendFeedback(string feedback)
    {
        Console.WriteLine(feedback);
    }
}