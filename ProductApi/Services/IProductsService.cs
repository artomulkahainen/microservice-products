using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetAllProducts();

    Task<IEnumerable<Product>> GetProductsByIds(List<Guid> ids);
}
