using MyWebProject.Models;
using MyWebProject.DTOs;
using MyWebProject.Week_6.Repositories;

namespace MyWebProject.Week_6.Services
{
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

            return companies.Select(company => new DeliveryCompanyResponse
            {
                Id = company.Id,
                Name = company.Name
            });
        }

        public async Task<DeliveryCompanyResponse?> GetCompanyAsync(int id)
        {
            var company = await _repository.GetByIdAsync(id);

            if (company == null)
                return null;

            return new DeliveryCompanyResponse
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        public async Task<IEnumerable<DeliveryCompanyResponse>> SearchCompaniesAsync(string name)
        {
            var companies = await _repository.SearchAsync(name);

            return companies.Select(company => new DeliveryCompanyResponse
            {
                Id = company.Id,
                Name = company.Name
            });
        }

        public async Task<DeliveryCompanyResponse> CreateCompanyAsync(
            CreateDeliveryCompanyRequest request)
        {
            var company = new DeliveryCompany
            {
                Name = request.Name
            };

            await _repository.AddAsync(company);

            return new DeliveryCompanyResponse
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        public async Task<DeliveryCompanyResponse?> UpdateCompanyAsync(
            int id,
            UpdateDeliveryCompanyRequest request)
        {
            var company = await _repository.GetByIdAsync(id);

            if (company == null)
                return null;

            company.Name = request.Name;

            await _repository.UpdateAsync(company);

            return new DeliveryCompanyResponse
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await _repository.GetByIdAsync(id);

            if (company == null)
                return false;

            await _repository.DeleteAsync(company);

            return true;
        }
    }
}