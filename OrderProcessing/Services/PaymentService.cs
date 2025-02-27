﻿namespace OrderProcessing.Services;
using OrderProcessing.Models;
using OrderProcessing.Interfaces;

public class PaymentService : IPaymentService
{
  public bool ProcessPayment(Customer customer, double amount)
  {
    Console.WriteLine($"Processing payment for {customer.Name} of amount {amount}");

    return true; // Assume payment is always successful
  }
}
