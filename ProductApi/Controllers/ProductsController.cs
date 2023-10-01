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
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await _productsService.GetAllProducts();

        return products.Select(ProductMapper.MapProductToProductDTO).ToArray();
    }

    [HttpPost("by-ids")]
    public async Task<IEnumerable<ProductDTO>> GetProductsByIds(
        [FromBody] GetProductsByIdsRequest request
    )
    {
        var products = await _productsService.GetProductsByIds(request.Ids);

        return products.Select(ProductMapper.MapProductToProductDTO).ToArray();
    }
}
