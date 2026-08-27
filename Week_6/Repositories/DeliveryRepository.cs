
using MyWebProject.Data;
using MyWebProject.Models;
public class DeliveryRepository : IDeliveryRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public DeliveryRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<Delivery?> GetByIdAsync(int id) =>
        await _context.Deliveries.FindAsync(id);

    public async Task AddAsync(Delivery delivery)
    {
        _context.Deliveries.Add(delivery);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Delivery delivery)
    {
        _context.Deliveries.Update(delivery);
        await _context.SaveChangesAsync();
    }
}
