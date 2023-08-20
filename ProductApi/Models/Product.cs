namespace ProductApi.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = "";
    public int Price { get; set; }
}
