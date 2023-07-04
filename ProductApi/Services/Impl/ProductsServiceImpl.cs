using ProductApi.Models;

namespace ProductApi.Services.Impl;

public class ProductsServiceImpl : IProductsService
{
    private static readonly string[] Products = new[] { "Banana", "Apple", "Orange" };

    public ProductsServiceImpl() { }

    public IEnumerable<Product> GetAllProducts()
    {
        return Enumerable
            .Range(0, 3)
            .Select(index => new Product { Name = Products[index] })
            .ToArray();
    }
}
