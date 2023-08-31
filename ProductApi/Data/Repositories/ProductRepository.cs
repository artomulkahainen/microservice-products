using ProductApi.Models;

namespace ProductApi.Data.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(ApiDbContext context)
        : base(context) { }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    /*public IEnumerable<Product> GetProductsByIds(List<Guid> ids)
    {
        var sql = $"SELECT * FROM Products WHERE id IN ({string.Join(",", ids)})";
        return _context.Products.FromSqlRaw(sql).ToList();
    }*/
}
