using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<Product> GetProductsByIds(List<Guid> ids)
    {
        var quotedIds = ids.Select(id => $"'{id}'");
        var sql = $"SELECT * FROM \"Products\" WHERE \"Id\" IN ({string.Join("','", quotedIds)})";
        return _context.Products.FromSqlRaw(sql).ToList();
    }
}
