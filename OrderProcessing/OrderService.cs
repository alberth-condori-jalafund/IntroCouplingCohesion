namespace OrderProcessing;

public class OrderService
{
    private Inventory _inventory;

    private PaymentService _paymentService;

    private EmailService _emailService;

    public OrderService()
    {
        _inventory = new();
        _paymentService = new();
        _emailService = new();
    }

    public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
    {
        if (!_inventory.AreAllItemsAvailable(items))
        {
            Console.WriteLine("Not all items are available in the requested quantities.");
            return;
        }

        double totalAmount = ReserveItemsAndCalculateTotal(items);

        var order = CreateOrder(customer, items, totalAmount);
        ProcessPayment(order);
    }

    private double ReserveItemsAndCalculateTotal(List<(string item, int quantity)> items)
    {
        double totalAmount = 0;
        foreach (var (item, quantity) in items)
        {
            _inventory.ReserveItem(item, quantity);
            totalAmount += 10 * quantity; // Assume each item costs 10 per unit
        }
        return totalAmount;
    }

    private Order CreateOrder(Customer customer, List<(string item, int quantity)> items, double totalAmount)
    {
        return new Order
        {
            Customer = customer,
            Items = new List<string>(items.ConvertAll(i => i.item)),
            TotalAmount = totalAmount
        };
    }

    private void ProcessPayment(Order order)
    {
        if (_paymentService.ProcessPayment(order.Customer, order.TotalAmount))
        {
            order.PaymentStatus = "Paid";
            _emailService.SendOrderConfirmationEmail(order.Customer, order);
        }
        else
        {
            order.PaymentStatus = "Payment Failed";
            _emailService.SendPaymentFailedEmail(order.Customer);
        }
    }
}
