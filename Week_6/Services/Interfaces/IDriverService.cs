using MyWebProject.DTOs;

public interface IDriverService
{
    Task<IEnumerable<DriverResponse>> GetAllDriversAsync();

    Task<DriverResponse?> GetDriverAsync(int id);

    Task<DriverResponse> CreateDriverAsync(
        CreateDriverRequest request);

    Task<DriverResponse> UpdateDriverStatusAsync(
        int id,
        UpdateDriverStatusRequest request);

    Task<bool> DeleteDriverAsync(int id);
}
