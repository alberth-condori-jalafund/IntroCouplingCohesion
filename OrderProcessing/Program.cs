namespace OrderProcessing;

public class Program
{
  public static void Main()
  {
    var inventory = new Inventory();

    var item1 = new Item(1, "Item1", 10);
    var item2 = new Item(2, "Item2", 5);
    var item3 = new Item(3, "Item3", 8);

    inventory.AddItem(item1, 10);
    inventory.AddItem(item2, 10);
    inventory.AddItem(item3, 10);

    var customer = new Customer ("Alberth Condori", "alberth.condori@example.com", "123 Main St");

    var orderService = new OrderService(inventory);


    var customerItems = new List<(Item, int)> { (item1, 5), (item2, 5), (item3, 5)};
    orderService.ProcessOrder(customer, customerItems);
  }
}
