﻿namespace OrderProcessing;

public class Program
{
  public static void Main()
  {
    var customer = new Customer { Name = "Alberth Condori", Email = "alberth.condori@example.com", Address = "123 Main St" };
    var items = new List<(string, int)> { ("Item1", 2), ("Item2", 1), ("Item3", 1) };
    var orderService = new OrderService();
    orderService.ProcessOrder(customer, items);
  }
}
