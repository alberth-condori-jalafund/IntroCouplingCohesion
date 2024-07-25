namespace OrderProcessing;

public class Program
{
  public static void Main()
        {
            var paymentService = new PaymentService();
            var emailService = new EmailService();
            var initialStock = new Dictionary<string, int>
            {
                { "Item1", 10 },
                { "Item2", 5 },
                { "Item3", 20 }
            };
            var inventory = new Inventory(initialStock);
            var customer = new Customer { Name = "Alberth Condori", Email = "alberth.condori@example.com", Address = "123 Main St" };
            var items = new List<(string, int)> { ("Item1", 2), ("Item2", 1), ("Item3", 1) };

            var orderService = new OrderService(inventory, paymentService, emailService);
            orderService.ProcessOrder(customer, items);
        }    
}


