using System;
using System.Collections.Generic;
using OrderProcessing.Models;
using OrderProcessing.Services;

namespace OrderProcessing
{
    public class Program
    {
        static void Main()
        {
            var customer = new Customer
            {
                Name = "Alberth Condori",
                Email = "alberth.condori@example.com",
                Address = "123 Main St"
            };
            var items = new List<(string, int)>
            {
                ("Item1", 2),
                ("Item2", 1),
                ("Item3", 1)
            };
            var orderService = new OrderService();
            var order = new Order
            {
                Customer = customer,
                Items = items,
                TotalAmount = 10
            };
            orderService.ProcessOrder(customer, items, order);
        }
    }
}
