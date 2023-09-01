using Microsoft.AspNetCore.Mvc.Testing;
using ProductApi.Dtos;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace ProductApi.Tests.ItTests;

public class ProductsControllerIT : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;
    private static readonly string API_URL = "/api/products";

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
        var response = await _client.GetAsync(API_URL);

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

    [Fact]
    public async Task GetProductsByIdsSuccessfully_withTwoItems()
    {
        var request = new GetProductsByIdsRequest(
            new List<Guid>()
            {
                Guid.Parse("2e4b8b6b-84cf-4dcd-a08a-2955cfab4dff"),
                Guid.Parse("834e0d94-76f6-4406-a28d-f270075d1298")
            }
        );

        var response = await _client.PostAsJsonAsync(API_URL + "/by-ids", request);
        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var jsonList = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(contentString);

        Assert.NotNull(jsonList);
        Assert.Equal(2, jsonList.Count());

        int appleCount = jsonList.Count(dto => dto.Name == "Apple");
        int bananaCount = jsonList.Count(dto => dto.Name == "Banana");

        Assert.Equal(1, appleCount);
        Assert.Equal(1, bananaCount);
    }

    [Fact]
    public async Task GetProductsByIdsSuccessfully_withoutItems()
    {
        var request = new GetProductsByIdsRequest(new List<Guid>() { });

        var response = await _client.PostAsJsonAsync(API_URL + "/by-ids", request);
        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var jsonList = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(contentString);

        Assert.NotNull(jsonList);
        Assert.Equal(0, jsonList.Count());
    }

    [Fact]
    public async Task GetProductsByIdsSuccessfully_returnEmptyList_ifNoElementsFound()
    {
        var request = new GetProductsByIdsRequest(
            new List<Guid>() { Guid.Parse("c260a22c-85b8-4e9a-a6ec-98081d71c6a5") }
        );

        var response = await _client.PostAsJsonAsync(API_URL + "/by-ids", request);
        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var jsonList = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(contentString);

        Assert.NotNull(jsonList);
        Assert.Equal(0, jsonList.Count());
    }
}
