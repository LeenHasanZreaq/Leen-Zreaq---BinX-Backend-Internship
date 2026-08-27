using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriversController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers() =>
        Ok(await _driverService.GetAllDriversAsync());

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] CreateDriverRequest request) =>
        Ok(await _driverService.CreateDriverAsync(request));

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateDriverStatusRequest request) =>
        Ok(await _driverService.UpdateDriverStatusAsync(id, request));
}
