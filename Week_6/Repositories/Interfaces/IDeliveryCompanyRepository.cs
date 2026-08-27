using MyWebProject.Models;

public interface IDeliveryCompanyRepository
{
    Task<IEnumerable<DeliveryCompany>> GetAllAsync();
    Task AddAsync(DeliveryCompany company);
}
