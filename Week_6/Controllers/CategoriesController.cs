using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public CategoriesController(
        ICategoryService categoryService,
        IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    // ========================================
    // GET: api/Categories
    // Get all categories
    // ========================================

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    // ========================================
    // GET: api/Categories/{id}
    // Get category by ID
    // ========================================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryAsync(id);

        if (category == null)
            return NotFound(new
            {
                message = "Category not found."
            });

        return Ok(category);
    }

    // ========================================
    // POST: api/Categories
    // Create category
    // ========================================

    [HttpPost]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CreateCategoryRequest request)
    {
        var category =
            await _categoryService.CreateCategoryAsync(request);

        return Ok(category);
    }

    // ========================================
    // PUT: api/Categories/{id}
    // Update category
    // ========================================

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(
        int id,
        [FromBody] UpdateCategoryRequest request)
    {
        var category =
            await _categoryService.UpdateCategoryAsync(id, request);

        if (category == null)
            return NotFound(new
            {
                message = "Category not found."
            });

        return Ok(category);
    }

    // ========================================
    // DELETE: api/Categories/{id}
    // Delete category
    // ========================================

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return NoContent();
    }

    // ========================================
    // GET: api/Categories/search?name=Pizza
    // Search categories by name
    // ========================================

    [HttpGet("search")]
    public async Task<IActionResult> SearchCategories(
        [FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new
            {
                message = "Search name is required."
            });
        }

        var categories =
            await _categoryService.GetAllCategoriesAsync();

        var result = categories
            .Where(c =>
                c.Name != null &&
                c.Name.Contains(
                    name,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(result);
    }

    // ========================================
    // GET: api/Categories/{id}/products
    // Get products belonging to a category
    // ========================================

    [HttpGet("{id}/products")]
    public async Task<IActionResult> GetCategoryProducts(int id)
    {
        var category =
            await _categoryService.GetCategoryAsync(id);

        if (category == null)
        {
            return NotFound(new
            {
                message = "Category not found."
            });
        }

        var products =
            await _productService.GetAllProductsAsync();

        var result = products
            .Where(p => p.CategoryId == id)
            .ToList();

        return Ok(result);
    }

    // ========================================
    // GET: api/Categories/{id}/product-count
    // Get number of products in category
    // ========================================

    [HttpGet("{id}/product-count")]
    public async Task<IActionResult> GetCategoryProductCount(int id)
    {
        var category =
            await _categoryService.GetCategoryAsync(id);

        if (category == null)
        {
            return NotFound(new
            {
                message = "Category not found."
            });
        }

        var products =
            await _productService.GetAllProductsAsync();

        var count =
            products.Count(p => p.CategoryId == id);

        return Ok(new
        {
            categoryId = id,
            productCount = count
        });
    }
}