namespace ProductApi.Dtos;

public record ProductDTO
{
    public int Id { get; init; }
    public string? Name { get; init; }
}
