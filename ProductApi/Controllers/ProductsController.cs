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
    public async Task<IActionResult> GetProducts()
    {
        return Ok(
            (await _productsService.GetAllProducts())
                .Select(ProductMapper.MapProductToProductDTO)
                .ToArray()
        );
    }

    [HttpPost("by-ids")]
    public async Task<IActionResult> GetProductsByIds([FromBody] GetProductsByIdsRequest request)
    {
        return Ok(
            (await _productsService.GetProductsByIds(request.Ids))
                .Select(ProductMapper.MapProductToProductDTO)
                .ToArray()
        );
    }
}
