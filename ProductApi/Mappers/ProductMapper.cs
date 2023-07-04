using ProductApi.Models;
using ProductApi.Dtos;

namespace ProductApi.Mappers;

public static class ProductMapper
{
    public static ProductDTO MapProductToProductDTO(int id, Product product)
    {
        return new ProductDTO { Id = id, Name = product.Name };
    }
}
