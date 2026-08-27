using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _productService.GetAllProductsAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request) =>
        Ok(await _productService.CreateProductAsync(request));
}
