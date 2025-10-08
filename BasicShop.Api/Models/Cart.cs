namespace BasicShop.Api.Models;

using BasicShop.Api.DTOs;

public record class CartDto(
    int Id,
    List<ItemDto> Items);
