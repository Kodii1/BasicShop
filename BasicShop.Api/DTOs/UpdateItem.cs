namespace BasicShop.Api.DTOs;

using BasicShop.Api.Enum;

public record class UpdateItemDto(
    int Id,
    string Name,
    string Description,
    double Price,
    int Quantity,
    Category Category
    );
