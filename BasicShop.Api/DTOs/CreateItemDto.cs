namespace BasicShop.Api.DTOs;

using BasicShop.Api.Enum;

public record class CreateItemDto(
    int Id,
    string Name,
    string Description,
    double Price,
    int Quantity,
    Category Category
    );
