namespace BasicShop.Api.Models;

using BasicShop.Api.Enum;

public class Item{
    public required string Name;
    public required string Description;
    public required decimal Price;
    public required int Quantity;
    public required Category Category;
    };
