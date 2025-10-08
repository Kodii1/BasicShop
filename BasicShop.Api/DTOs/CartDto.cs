namespace BasicShop.Api.DTOs;

public record class CartDto(
    int Id,
    List<ItemDto> Items);
