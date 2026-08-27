public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
    Task<ProductResponse> CreateProductAsync(CreateProductRequest request);
}
