using Microsoft.AspNetCore.Mvc.Testing;
using ProductApi.Dtos;
using System.Text.Json;

namespace ProductApi.Tests.ItTests;

public class ProfileControllerIT : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly string apiUrl = "/api/products";

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

        var jsonList = JsonSerializer.Deserialize<IEnumerable<ProductDTO>>(
            await response.Content.ReadAsStringAsync()
        );

        Assert.NotNull(jsonList);
        Assert.Equal(4, jsonList.Count());

        var names = jsonList.Select(item => item.Name);
        Assert.Contains("Banana", names);
    }
}
