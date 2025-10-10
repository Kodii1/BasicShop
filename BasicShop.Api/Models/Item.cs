namespace BasicShop.Api.Models;

using BasicShop.Api.Enum;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
    public required Category Category { get; set; }
}
