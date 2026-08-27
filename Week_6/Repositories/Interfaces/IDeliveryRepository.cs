
using MyWebProject.Models;
public interface IDeliveryRepository
{
    Task<Delivery?> GetByIdAsync(int id);
    Task AddAsync(Delivery delivery);
    Task UpdateAsync(Delivery delivery);
}
