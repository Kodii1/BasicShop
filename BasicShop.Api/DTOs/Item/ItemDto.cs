namespace BasicShop.Api.DTOs;

using BasicShop.Api.Enum;

public record class ItemDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    Category Category
    );
