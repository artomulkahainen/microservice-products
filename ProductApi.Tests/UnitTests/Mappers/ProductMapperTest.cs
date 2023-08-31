using ProductApi.Mappers;
using ProductApi.Models;

namespace ProductApi.Tests.UnitTests.Mappers
{
    public class ProductMapperTest
    {
        [Fact]
        public void MapsDtoOk()
        {
            var product = new Product
            {
                Id = Guid.Parse("2e4b8b6b-84cf-4dcd-a08a-2955cfab4dff"),
                Name = "Nice",
                Price = new decimal(1.2)
            };
            var dto = ProductMapper.MapProductToProductDTO(product);

            Assert.Equal(Guid.Parse("2e4b8b6b-84cf-4dcd-a08a-2955cfab4dff"), dto.Id);
            Assert.Equal("Nice", dto.Name);
            Assert.Equal(new decimal(1.2), dto.Price);
        }
    }
}
