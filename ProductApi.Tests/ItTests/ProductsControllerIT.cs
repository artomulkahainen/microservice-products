using Microsoft.AspNetCore.Mvc.Testing;
using ProductApi.Dtos;
using Newtonsoft.Json;

namespace ProductApi.Tests.ItTests;

public class ProfileControllerIT : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private static string apiUrl = "/api/products";

    public ProfileControllerIT(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAllProductsSuccessfully()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync(apiUrl);

        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var jsonList = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(contentString);

        Assert.NotNull(jsonList);
        Assert.Equal(3, jsonList.Count());

        var names = jsonList.Select(item => item.Name);
        Assert.Contains("Banana", names);
    }
}
