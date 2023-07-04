using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductsService
{
    IEnumerable<Product> GetAllProducts();
}
