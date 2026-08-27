using MyWebProject.Models;
using MyWebProject.DTOs;

namespace MyWebProject.Week_6.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderItemResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                TableId = request.TableId,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(order);

            return new OrderItemResponse
            {
                Id = order.Id,
                Status = order.Status,
                CreatedAt = order.CreatedAt
            };
        }

        public async Task<OrderItemResponse> UpdateOrderStatusAsync(int id, UpdateOrderStatusRequest request)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found");

            order.Status = request.Status;
            await _repository.UpdateAsync(order);

            return new OrderItemResponse { Id = order.Id, Status = order.Status, CreatedAt = order.CreatedAt };
        }

        public async Task<OrderItemResponse> AddOrderItemAsync(int orderId, CreateOrderItemRequest request)
        {
            var item = new OrderItem
            {
                OrderId = orderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            await _repository.AddItemAsync(item);

            return new OrderItemResponse
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = "ProductNameHere", // لازم تجيبي الاسم من DbContext أو Repository
                Quantity = item.Quantity
            };
        }

        public async Task RemoveOrderItemAsync(int orderId, int itemId)
        {
            await _repository.RemoveItemAsync(orderId, itemId);
        }

        Task<OrderItemResponse> IOrderService.AddOrderItemAsync(int orderId, CreateOrderItemRequest request)
        {
            return AddOrderItemAsync(orderId, request);
        }
    }
}
