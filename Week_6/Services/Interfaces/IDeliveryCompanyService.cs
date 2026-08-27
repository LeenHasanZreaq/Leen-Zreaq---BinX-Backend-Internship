public interface IDeliveryCompanyService
{
    Task<IEnumerable<DeliveryCompanyResponse>> GetAllCompaniesAsync();
    Task<DeliveryCompanyResponse> CreateCompanyAsync(CreateDeliveryCompanyRequest request);
}
