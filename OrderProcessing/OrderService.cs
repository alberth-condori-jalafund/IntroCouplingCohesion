namespace OrderProcessing;

public class OrderService
{
    private readonly Inventory _inventory;
    private readonly PaymentService _paymentService;
    private readonly EmailService _emailService;
    private const double ItemPrice = 10.0;

    public OrderService(Inventory inventory, PaymentService paymentService, EmailService emailService)
    {
        _inventory = inventory;
        _paymentService = paymentService;
        _emailService = emailService;
    }

    public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
    {
        if (AreAllItemsAvailable(items, out double totalAmount))
        {
            var order = CreateOrder(customer, items, totalAmount);

            if (ProcessPayment(customer, order))
            {
                _emailService.SendOrderConfirmationEmail(customer, order);
            }
            else
            {
                _emailService.SendPaymentFailedEmail(customer);
            }
        }
    }

    private bool AreAllItemsAvailable(List<(string item, int quantity)> items, out double totalAmount)
    {
        totalAmount = 0;
        bool allItemsAvailable = true;

        foreach (var (item, quantity) in items)
        {
            if (_inventory.CheckItemAvailability(item, quantity))
            {
                _inventory.ReserveItem(item, quantity);
                totalAmount += ItemPrice * quantity;
            }
            else
            {
                allItemsAvailable = false;
                Console.WriteLine($"Item {item} is not available in the requested quantity.");
            }
        }

        return allItemsAvailable;
    }

    private Order CreateOrder(Customer customer, List<(string item, int quantity)> items, double totalAmount)
    {
        return new Order
        {
            Customer = customer,
            Items = new List<string>(items.ConvertAll(i => i.item)),
            TotalAmount = totalAmount,
            PaymentStatus = "Pending"
        };
    }

    private bool ProcessPayment(Customer customer, Order order)
    {
        if (_paymentService.ProcessPayment(customer, order.TotalAmount))
        {
            order.PaymentStatus = "Paid";
            return true;
        }
        else
        {
            order.PaymentStatus = "Payment Failed";
            return false;
        }
    }
}
