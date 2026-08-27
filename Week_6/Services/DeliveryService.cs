using MyWebProject.Models;
using MyWebProject.DTOs;
public class DriverService : IDriverService
{
    private readonly IDriverRepository _repository;

    public DriverService(IDriverRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DriverResponse>> GetAllDriversAsync()
    {
        var drivers = await _repository.GetAllAsync();
        return drivers.Select(d => new DriverResponse
        {
            Id = d.Id,
            FullName = d.FullName,
            Phone = d.Phone,
            Status = d.Status,
            DeliveryCompanyId = d.DeliveryCompanyId
        });
    }

    public async Task<DriverResponse> CreateDriverAsync(CreateDriverRequest request)
    {
        var driver = new Driver
        {
            FullName = request.FullName,
            Phone = request.Phone,
            Status = "Available",
            DeliveryCompanyId = request.DeliveryCompanyId
        };

        await _repository.AddAsync(driver);

        return new DriverResponse
        {
            Id = driver.Id,
            FullName = driver.FullName,
            Phone = driver.Phone,
            Status = driver.Status,
            DeliveryCompanyId = driver.DeliveryCompanyId
        };
    }

    public async Task<DriverResponse> UpdateDriverStatusAsync(int id, UpdateDriverStatusRequest request)
    {
        var driver = await _repository.GetByIdAsync(id);
        if (driver == null) throw new Exception("Driver not found");

        driver.Status = request.Status;
        await _repository.UpdateAsync(driver);

        return new DriverResponse
        {
            Id = driver.Id,
            FullName = driver.FullName,
            Phone = driver.Phone,
            Status = driver.Status,
            DeliveryCompanyId = driver.DeliveryCompanyId
        };
    }
}
