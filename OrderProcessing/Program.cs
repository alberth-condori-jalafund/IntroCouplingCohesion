namespace OrderProcessing
{
  using OrderProcessing.Interfaces;
  using OrderProcessing.Models;
  using OrderProcessing.Services;
  using System;
  using System.Collections.Generic;

  public class Program
  {
    public static void Main(string[] args)
    {
      IInventory inventory = new Inventory();
      IPaymentService paymentService = new PaymentService();
      IEmailService emailService = new EmailService();
      var orderService = new OrderService(inventory, paymentService, emailService);

      var customer = new Customer("John Doe", "john@example.com", "123 Main St");
      var items = new List<(string item, int quantity)>
            {
                ("Item1", 2),
                ("Item2", 1),
                ("Item3", 5)
            };

      orderService.ProcessOrder(customer, items);
    }
  }
}