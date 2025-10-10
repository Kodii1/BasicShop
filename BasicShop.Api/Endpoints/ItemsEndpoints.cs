using BasicShop.Api.Data;
using BasicShop.Api.DTOs;
using BasicShop.Api.Mappers.Item;
using BasicShop.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicShop.Api.Endpoints;

public static class ItemsEndpoints
{

    const string GetItemEndpointName = "GetItem";

    public static RouteGroupBuilder MapItemEndpoints(this WebApplication app)
    {
        var groups = app.MapGroup("items").WithParameterValidation();

        //GET items
        groups.MapGet("/", (BasicStoreContext dbContext) =>
            dbContext.Items
                            .Select(item => item.ToDto())
                            .AsNoTracking());


        //GET item/{id}
        groups.MapGet("/{id}", (int id, BasicStoreContext dbContext) =>
            {
                Item? item = dbContext.Items.Find(id);

                return item is null ? Results.NotFound() : Results.Ok(item.ToDto());
            }).WithName(GetItemEndpointName);

        //POST items
        groups.MapPost("/", (CreateItemDto newItem, BasicStoreContext dbContext) =>
            {
                Item item = new()
                {
                    Name = newItem.Name,
                    Description = newItem.Description,
                    Price = newItem.Price,
                    Quantity = newItem.Quantity,
                    Category = newItem.Category
                };

                dbContext.Items.Add(item);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute("GetItem", new { id = item.Id }, item.ToDto());
            });

        //PUT items
        groups.MapPut("/{id}", (int id, UpdateItemDto updateItem, BasicStoreContext dbContext) =>
            {
                var existingItem = dbContext.Items.Find(id);

                if (existingItem is null)
                {
                    return Results.NotFound();
                }
                dbContext.Entry(existingItem)
                                .CurrentValues
                                .SetValues(updateItem.ToModel(id));

                dbContext.SaveChanges();
                return Results.NoContent();
            });

        //DELETE items/{id}
        groups.MapDelete("/{id}", (int id, BasicStoreContext dbContext) =>
            {
                dbContext.Items
                                .Where(item => item.Id == id)
                                .ExecuteDelete();


                return Results.NoContent();
            });

        return groups;
    }
}
