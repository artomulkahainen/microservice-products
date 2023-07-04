using ProductApi.Mappers;
using ProductApi.Models;

namespace ProductApi.Tests.UnitTests.Mappers
{
    public class ProductMapperTest
    {
        [Fact]
        public void MapsDtoOk()
        {
            const var product = new Product { Name = "Nice" };
            const var dto = ProductMapper.MapProductToProductDTO(1, product);

            Assert.Equal(dto.Id, 1);
            Assert.Equal("Nice", dto.Name);
        }
    }
}
