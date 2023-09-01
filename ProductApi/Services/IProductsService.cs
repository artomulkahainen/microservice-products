using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductsService
{
    IEnumerable<Product> GetAllProducts();

    IEnumerable<Product> GetProductsByIds(List<Guid> ids);
}
