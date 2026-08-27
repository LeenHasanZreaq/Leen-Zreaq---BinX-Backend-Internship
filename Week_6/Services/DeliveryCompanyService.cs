using MyWebProject.Models;
using MyWebProject.DTOs;
public class DeliveryCompanyService : IDeliveryCompanyService
{
    private readonly IDeliveryCompanyRepository _repository;

    public DeliveryCompanyService(IDeliveryCompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DeliveryCompanyResponse>> GetAllCompaniesAsync()
    {
        var companies = await _repository.GetAllAsync();
        return companies.Select(c => new DeliveryCompanyResponse { Id = c.Id, Name = c.Name });
    }

    public async Task<DeliveryCompanyResponse> CreateCompanyAsync(CreateDeliveryCompanyRequest request)
    {
        var company = new DeliveryCompany { Name = request.Name };
        await _repository.AddAsync(company);
        return new DeliveryCompanyResponse { Id = company.Id, Name = company.Name };
    }
}
