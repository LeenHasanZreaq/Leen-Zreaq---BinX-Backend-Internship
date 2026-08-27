using MyWebProject.Models;
public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task AddItemAsync(OrderItem item);
    Task RemoveItemAsync(int orderId, int itemId);
}
