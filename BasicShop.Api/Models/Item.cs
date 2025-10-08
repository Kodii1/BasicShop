namespace BasicShop.Api.Models;

using BasicShop.Api.Enum;

public record class Item(
    string Name,
    string Description,
    double Price,
    int Quantity,
    Category Category
    );
