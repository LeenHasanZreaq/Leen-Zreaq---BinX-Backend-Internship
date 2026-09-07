using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

namespace MyWebProject.Week_6.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly PizzaRestaurantDbContext _context;

        public DeliveryRepository(PizzaRestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery?> GetByIdAsync(int id)
        {
            return await _context.Deliveries
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Deliveries
                .Include(d => d.Driver)
                .ToListAsync();
        }

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

        public async Task DeleteAsync(Delivery delivery)
        {
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
        }
    }
}