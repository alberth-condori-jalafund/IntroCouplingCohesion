namespace OrderProcessing;

public interface IInventoryService
{
  bool CheckItemAvailability(RequestOrderItem item);

  bool TryReserveItem(RequestOrderItem item);
}
