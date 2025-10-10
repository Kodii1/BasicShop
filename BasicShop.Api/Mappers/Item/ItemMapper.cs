namespace BasicShop.Api.Mappers.Item;

using BasicShop.Api.DTOs;
using BasicShop.Api.Models;

public static class ItemMapper
{
    public static ItemDto ToDto(this Item item)
    {

        return new ItemDto(
            item.Id,
            item.Name,
            item.Description,
            item.Price,
            item.Quantity,
            item.Category
            );
    }

    public static Item ToModel(this ItemDto dto)
    {
      return new Item
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Category = dto.Category
        };
    }

    public static UpdateItemDto ToUpdateDto(this Item item)
    {

        return new UpdateItemDto(
            item.Name,
            item.Description,
            item.Price,
            item.Quantity,
            item.Category
            );
    }

    public static Item ToModel(this UpdateItemDto updateDto, int id)
    {
      return new Item
        {
            Id = id,
            Name =  updateDto.Name,
            Description =  updateDto.Description,
            Price = updateDto.Price,
            Quantity = updateDto.Quantity,
            Category = updateDto.Category
        };
    }
}
