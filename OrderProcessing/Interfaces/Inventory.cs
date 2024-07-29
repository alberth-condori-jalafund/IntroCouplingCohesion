namespace OrderProcessing.Interfaces;

public interface IInventory
{
    bool CheckItemAvailability(string item, int quantity);
    void ReserveItem(string item, int quantity);
    void RestockItem(string item, int quantity);
}