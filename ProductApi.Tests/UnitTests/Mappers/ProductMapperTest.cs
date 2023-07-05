using ProductApi.Mappers;
using ProductApi.Models;

namespace ProductApi.Tests.UnitTests.Mappers
{
    public class ProductMapperTest
    {
        [Fact]
        public void MapsDtoOk()
        {
            var product = new Product { Name = "Nice" };
            var dto = ProductMapper.MapProductToProductDTO(1, product);

            Assert.Equal(1, dto.Id);
            Assert.Equal("Nice", dto.Name);
        }
    }
}
