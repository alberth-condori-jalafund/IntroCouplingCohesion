namespace OrderProcessing.Services
{
  using OrderProcessing.Models;
  using OrderProcessing.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class OrderService
  {
    private readonly IInventory _inventory;
    private readonly IPaymentService _paymentService;
    private readonly IEmailService _emailService;

    public OrderService(IInventory inventory, IPaymentService paymentService, IEmailService emailService)
    {
      _inventory = inventory;
      _paymentService = paymentService;
      _emailService = emailService;
    }

    public void ProcessOrder(Customer customer, List<(string item, int quantity)> items)
    {
      if (!CheckAndReserveItems(items, out double totalAmount))
      {
        NotifyItemsUnavailable(items);
        return;
      }

      var order = CreateOrder(customer, items, totalAmount);
      ProcessPaymentAndNotify(customer, order);
    }

    private bool CheckAndReserveItems(List<(string item, int quantity)> items, out double totalAmount)
    {
      totalAmount = 0;
      bool allItemsAvailable = true;

      foreach (var (item, quantity) in items)
      {
        if (_inventory.CheckItemAvailability(item, quantity))
        {
          _inventory.ReserveItem(item, quantity);
          totalAmount += 10 * quantity; // Assume each item costs 10 per unit
        }
        else
        {
          allItemsAvailable = false;
        }
      }

      return allItemsAvailable;
    }

    private void NotifyItemsUnavailable(List<(string item, int quantity)> items)
    {
      foreach (var (item, quantity) in items)
      {
        if (!_inventory.CheckItemAvailability(item, quantity))
        {
          Console.WriteLine($"Item {item} is not available in the requested quantity.");
        }
      }
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

    private void ProcessPaymentAndNotify(Customer customer, Order order)
    {
      if (_paymentService.ProcessPayment(customer, order.TotalAmount))
      {
        order.PaymentStatus = "Paid";
        _emailService.SendOrderConfirmationEmail(customer, order);
      }
      else
      {
        order.PaymentStatus = "Payment Failed";
        _emailService.SendPaymentFailedEmail(customer);
      }
    }
  }
}
