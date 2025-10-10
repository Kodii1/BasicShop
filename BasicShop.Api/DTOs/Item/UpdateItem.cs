namespace BasicShop.Api.DTOs;

using System.ComponentModel.DataAnnotations;
using BasicShop.Api.Enum;

public record class UpdateItemDto(
    [Required] string Name,
    [Required] string Description,
    [Required] decimal Price,
    [Required] int Quantity,
    [Required] Category Category
    );
