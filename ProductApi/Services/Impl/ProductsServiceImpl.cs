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

    public IEnumerable<Product> GetAllProducts()
    {
        return _repository.GetAllProducts();
    }

    public IEnumerable<Product> GetProductsByIds(List<Guid> ids)
    {
        return _repository.GetProductsByIds(ids);
    }
}
