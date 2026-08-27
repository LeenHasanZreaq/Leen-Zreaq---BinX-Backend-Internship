public interface IDriverService
{
    Task<IEnumerable<DriverResponse>> GetAllDriversAsync();
    Task<DriverResponse> CreateDriverAsync(CreateDriverRequest request);
    Task<DriverResponse> UpdateDriverStatusAsync(int id, UpdateDriverStatusRequest request);
}
