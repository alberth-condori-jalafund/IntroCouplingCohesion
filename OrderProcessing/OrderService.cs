namespace OrderProcessing
{
    public class OrderService
    {
        private readonly Inventory _inventory;
        private readonly PaymentService _paymentService;
        private readonly EmailService _emailService;

        public OrderService(Inventory inventory, PaymentService paymentService, EmailService emailService)
        {
            _inventory = inventory;
            _paymentService = paymentService;
            _emailService = emailService;
        }

        public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
        {
            if (!AllItemsInStock(items))
            {
                Console.WriteLine("One or more items are not available in the requested quantity.");
                return;
            }

            var (totalAmount, reservedItems) = ReserveItemsAndCalculateTotal(items);
            var order = CreateOrder(customer, items, totalAmount);

            bool isPaymentSuccessful = ProcessPayment(customer, order.TotalAmount);

            UpdateOrderStatus(order, isPaymentSuccessful);
            NotifyCustomer(customer, order, isPaymentSuccessful);
        }

        private bool AllItemsInStock(List<(string item, int quantity)> items)
        {
            return items.All(item => _inventory.CheckItemAvailability(item.item, item.quantity));
        }

        private (double totalAmount, List<(string item, int quantity)> reservedItems) ReserveItemsAndCalculateTotal(List<(string item, int quantity)> items)
        {
            double totalAmount = 0;
            var reservedItems = new List<(string item, int quantity)>();

            foreach (var (item, quantity) in items)
            {
                _inventory.ReserveItem(item, quantity);
                totalAmount += 10 * quantity; 
                reservedItems.Add((item, quantity));
            }

            return (totalAmount, reservedItems);
        }

        private Order CreateOrder(Customer customer, List<(string item, int quantity)> items, double totalAmount)
        {
            return new Order
            {
                Customer = customer,
                Items = items.Select(i => i.item).ToList(),
                TotalAmount = totalAmount
            };
        }

        private bool ProcessPayment(Customer customer, double totalAmount)
        {
            return _paymentService.ProcessPayment(customer, totalAmount);
        }

        private void UpdateOrderStatus(Order order, bool isPaymentSuccessful)
        {
            order.PaymentStatus = isPaymentSuccessful ? "Paid" : "Payment Failed";
        }

        private void NotifyCustomer(Customer customer, Order order, bool isPaymentSuccessful)
        {
            SendEmail(customer, order, isPaymentSuccessful);
        }

        private void SendEmail(Customer customer, Order order, bool isPaymentSuccessful)
        {
            if (isPaymentSuccessful)
            {
                _emailService.SendOrderConfirmationEmail(customer, order);
            }
            else
            {
                _emailService.SendPaymentFailedEmail(customer);
            }
        }
    }
}

