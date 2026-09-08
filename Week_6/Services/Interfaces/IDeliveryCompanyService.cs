
public interface IDeliveryCompanyService
{
    Task<IEnumerable<DeliveryCompanyResponse>> GetAllCompaniesAsync();

    Task<DeliveryCompanyResponse?> GetCompanyAsync(int id);

    Task<IEnumerable<DeliveryCompanyResponse>> SearchCompaniesAsync(
        string name);

    Task<DeliveryCompanyResponse> CreateCompanyAsync(
        CreateDeliveryCompanyRequest request);

    Task<DeliveryCompanyResponse?> UpdateCompanyAsync(
        int id,
        UpdateDeliveryCompanyRequest request);

    Task<bool> DeleteCompanyAsync(int id);
}

