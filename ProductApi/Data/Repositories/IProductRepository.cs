using ProductApi.Models;

namespace ProductApi.Data.Repositories;

public interface IProductRepository : IDisposable
{
    Task<IEnumerable<Product>> GetAllProducts();

    Task<IEnumerable<Product>> GetProductsByIds(List<Guid> ids);
}
