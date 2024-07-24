namespace OrderProcessing;

public class OrderService
{
    private readonly Inventory _inventory;
    private readonly PaymentService _paymentService;
    private readonly EmailService _emailService;
    private const double UnitPrice = 10; // Assume each item costs 10 per unit

    public OrderService(Inventory inventory, PaymentService paymentService, EmailService emailService)
    {
        _inventory = inventory;
        _paymentService = paymentService;
        _emailService = emailService;
    }

    public void ProcessOrder(Customer customer, List<(string ItemName, int Quantity)> items)
    {
        var order = new Order { Customer = customer };

        if (!ValidateAndReserveItems(items, order))
        {
            return;
        }

        if (_paymentService.ProcessPayment(customer, order.TotalAmount))
        {
            CompleteOrder(order);
        }
        else
        {
            FailOrder(order);
        }
    }

    private bool ValidateAndReserveItems(List<(string ItemName, int Quantity)> items, Order order)
    {
        foreach (var (itemName, quantity) in items)
        {
            if (!_inventory.CheckItemAvailability(itemName, quantity))
            {
                Console.WriteLine($"Item {itemName} is not available in the requested quantity.");
                return false;
            }

            _inventory.ReserveItem(itemName, quantity);
            order.Items.Add((itemName, quantity));
            order.TotalAmount += UnitPrice * quantity;
        }

        return true;
    }

    private void CompleteOrder(Order order)
    {
        order.PaymentStatus = "Paid";
        _emailService.SendOrderConfirmationEmail(order.Customer, order);
    }

    private void FailOrder(Order order)
    {
        order.PaymentStatus = "Payment Failed";
        _emailService.SendPaymentFailedEmail(order.Customer);
    }
}
