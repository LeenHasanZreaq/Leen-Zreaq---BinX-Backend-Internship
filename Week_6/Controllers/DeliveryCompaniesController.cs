using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DeliveryCompaniesController : ControllerBase
{
    private readonly IDeliveryCompanyService _deliveryCompanyService;

    public DeliveryCompaniesController(IDeliveryCompanyService deliveryCompanyService)
    {
        _deliveryCompanyService = deliveryCompanyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies() =>
        Ok(await _deliveryCompanyService.GetAllCompaniesAsync());

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateDeliveryCompanyRequest request) =>
        Ok(await _deliveryCompanyService.CreateCompanyAsync(request));
}
