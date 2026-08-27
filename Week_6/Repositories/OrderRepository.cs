using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

public class OrderRepository : IOrderRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public OrderRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task AddItemAsync(OrderItem item)
    {
        _context.OrderItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveItemAsync(int orderId, int itemId)
    {
        var item = await _context.OrderItems.FirstOrDefaultAsync(i => i.Id == itemId && i.OrderId == orderId);
        if (item != null)
        {
            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    Task<Order?> IOrderRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task IOrderRepository.AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    Task IOrderRepository.UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    Task IOrderRepository.AddItemAsync(OrderItem item)
    {
        throw new NotImplementedException();
    }
}
