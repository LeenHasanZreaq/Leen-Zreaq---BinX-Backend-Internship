
using MyWebProject.Models;
public interface IDeliveryRepository
{
    Task<Delivery?> GetByIdAsync(int id);
    Task AddAsync(Delivery delivery);
    Task UpdateAsync(Delivery delivery);
    Task DeleteAsync(Delivery delivery);
    Task<IEnumerable<Delivery>> GetAllAsync();
}
