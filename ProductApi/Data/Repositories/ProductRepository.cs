using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(ApiDbContext context)
        : base(context) { }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByIds(List<Guid> ids)
    {
        return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
    }
}
