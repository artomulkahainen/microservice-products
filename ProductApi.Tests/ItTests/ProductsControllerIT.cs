using Microsoft.AspNetCore.Mvc.Testing;
using ProductApi.Dtos;
using Newtonsoft.Json;

namespace ProductApi.Tests.ItTests;

public class ProductsControllerIT : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;
    private static readonly string apiUrl = "/api/products";

    public ProductsControllerIT(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient(
            new WebApplicationFactoryClientOptions { AllowAutoRedirect = false }
        );
    }

    [Fact]
    public async Task GetAllProductsSuccessfully()
    {
        var response = await _client.GetAsync(apiUrl);

        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var jsonList = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(contentString);

        Assert.NotNull(jsonList);
        Assert.Equal(5, jsonList.Count());

        var itemNames = new List<string>()
        {
            "Banana",
            "Gummy bear",
            "Apple",
            "Orange",
            "Apple juice"
        };

        foreach (var item in jsonList)
        {
            Assert.Contains(item.Name, itemNames);
        }
    }
}
