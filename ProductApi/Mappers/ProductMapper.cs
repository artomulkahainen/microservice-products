using ProductApi.Models;
using ProductApi.Dtos;

namespace ProductApi.Mappers;

public static class ProductMapper
{
    public static ProductDTO MapProductToProductDTO(Product product)
    {
        return new(product.Id, product.Name, product.Price);
    }
}
