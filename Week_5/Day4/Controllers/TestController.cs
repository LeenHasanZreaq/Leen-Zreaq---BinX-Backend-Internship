using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ProductCalculator _calculator;

    public TestController(ProductCalculator calculator)
    {
        _calculator = calculator;
    }

    [HttpGet("calculate")]
    public IActionResult Calculate(
        decimal price,
        int discountPercentage)
    {
        try
        {
            var result = _calculator.CalculateFinalPrice(
                price,
                discountPercentage);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}