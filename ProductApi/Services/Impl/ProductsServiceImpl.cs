using ProductApi.Models;
using ProductApi.Data.Repositories;

namespace ProductApi.Services.Impl;

public class ProductsServiceImpl : IProductsService
{
    private readonly IProductRepository _repository;

    public ProductsServiceImpl(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _repository.GetAllProducts();
    }

    public async Task<IEnumerable<Product>> GetProductsByIds(List<Guid> ids)
    {
        return await _repository.GetProductsByIds(ids);
    }
}
