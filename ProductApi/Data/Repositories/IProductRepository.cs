using ProductApi.Models;

namespace ProductApi.Data.Repositories;

public interface IProductRepository : IDisposable
{
    IEnumerable<Product> GetAllProducts();

    IEnumerable<Product> GetProductsByIds(List<Guid> ids);
}
