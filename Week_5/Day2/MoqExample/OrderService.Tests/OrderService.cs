namespace OrderService;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
}

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<decimal> GetOrderTotalAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            throw new InvalidOperationException("Order not found");

        return order.Total;
    }
}