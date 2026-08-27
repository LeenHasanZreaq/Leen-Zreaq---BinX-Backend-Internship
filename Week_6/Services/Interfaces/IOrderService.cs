using MyWebProject.DTOs;

public interface IOrderService
{
    Task<OrderItemResponse> CreateOrderAsync(CreateOrderRequest request);
    Task<OrderItemResponse> UpdateOrderStatusAsync(int id, UpdateOrderStatusRequest request);
    Task<OrderItemResponse> AddOrderItemAsync(int orderId, CreateOrderItemRequest request);
    Task RemoveOrderItemAsync(int orderId, int itemId);
}
