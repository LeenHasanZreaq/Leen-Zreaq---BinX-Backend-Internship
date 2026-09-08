using MyWebProject.Models;

namespace MyWebProject.Week_6.Repositories
{
    public interface IDeliveryCompanyRepository
    {
        Task<DeliveryCompany?> GetByIdAsync(int id);
        Task<IEnumerable<DeliveryCompany>> GetAllAsync();

        Task<IEnumerable<DeliveryCompany>> SearchAsync(string name);

        Task AddAsync(DeliveryCompany company);

        Task UpdateAsync(DeliveryCompany company);

        Task DeleteAsync(DeliveryCompany company);
    }

}
