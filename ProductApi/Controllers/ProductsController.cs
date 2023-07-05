using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Mappers;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public IEnumerable<ProductDTO> GetProducts()
    {
        return _productsService
            .GetAllProducts()
            .Select((product, index) => ProductMapper.MapProductToProductDTO(index, product))
            .ToArray();
    }
}
