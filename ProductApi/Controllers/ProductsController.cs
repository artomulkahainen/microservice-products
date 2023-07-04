using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Mappers;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductsService _productsService;

    public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
    {
        _logger = logger;
        _productsService = productsService;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<ProductDTO> GetProducts()
    {
        return _productsService
            .GetAllProducts()
            .Select((product, index) => ProductMapper.MapProductToProductDTO(index, product))
            .ToArray();
    }
}
