using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DeliveryCompaniesController : ControllerBase
{
    private readonly IDeliveryCompanyService _deliveryCompanyService;

    public DeliveryCompaniesController(
        IDeliveryCompanyService deliveryCompanyService)
    {
        _deliveryCompanyService = deliveryCompanyService;
    }

    // GET: api/DeliveryCompanies
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies =
            await _deliveryCompanyService.GetAllCompaniesAsync();

        return Ok(companies);
    }

    // GET: api/DeliveryCompanies/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company =
            await _deliveryCompanyService.GetCompanyAsync(id);

        if (company == null)
        {
            return NotFound(new
            {
                message = "Delivery company not found."
            });
        }

        return Ok(company);
    }

    // GET: api/DeliveryCompanies/search?name=Aramex
    [HttpGet("search")]
    public async Task<IActionResult> SearchCompanies(
        [FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new
            {
                message = "Search name cannot be empty."
            });
        }

        var companies =
            await _deliveryCompanyService.SearchCompaniesAsync(name);

        return Ok(companies);
    }

    // POST: api/DeliveryCompanies
    [HttpPost]
    public async Task<IActionResult> CreateCompany(
        [FromBody] CreateDeliveryCompanyRequest request)
    {
        var company =
            await _deliveryCompanyService.CreateCompanyAsync(request);

        return Ok(company);
    }

    // PUT: api/DeliveryCompanies/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(
        int id,
        [FromBody] UpdateDeliveryCompanyRequest request)
    {
        var company =
            await _deliveryCompanyService.UpdateCompanyAsync(
                id,
                request);

        if (company == null)
        {
            return NotFound(new
            {
                message = "Delivery company not found."
            });
        }

        return Ok(company);
    }

    // DELETE: api/DeliveryCompanies/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var deleted =
            await _deliveryCompanyService.DeleteCompanyAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Delivery company not found."
            });
        }

        return NoContent();
    }
}

internal interface IDeliveryCompanyService
{
}