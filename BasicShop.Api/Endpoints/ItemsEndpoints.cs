namespace BasicShop.Api.Endpoints;

using BasicShop.Api.DTOs;
using BasicShop.Api.Enum;

public static class ItemsEndpoints{

  const string GetItemEndpointName = "GetItem";
  private static readonly List<ItemDto> listOfItems = [
    new (1,
        "Apple",
        "Red fruit",
        12.50,
        3,
        Category.Fruits
        ),

    new (2,
        "Red Car",
        "BMW with colour red",
        120000.50,
        1,
        Category.Cars
        ),
  ];

  public static RouteGroupBuilder MapItemEndpoints(this WebApplication app){
    var groups = app.MapGroup("items");

    //GET items
    groups.MapGet("/", () => listOfItems);


    //GET item/{id}
    groups.MapGet("/{id}", (int id) =>
        {
          ItemDto? item = listOfItems.Find(item => item.Id == id);

          return item is null ? Results.NotFound() : Results.Ok(item);
        }).WithName(GetItemEndpointName);

    //POST items
    groups.MapPost("/", (CreateItemDto newItem) =>
        {
          ItemDto item = new(
              listOfItems.Count() + 1,
              newItem.Name,
              newItem.Description,
              newItem.Price,
              newItem.Quantity,
              newItem.Category
              );
          listOfItems.Add(item);
          return Results.CreatedAtRoute("GetItem", new {id = item.Id}, item);
        });

    //PUT items
    groups.MapPut("/{id}", (int id, UpdateItemDto updateItem) =>
        {
          var index = listOfItems.FindIndex(item => item.Id == id);

          if(index == -1)
          {
            return Results.NotFound();
          }

          listOfItems[index] = new ItemDto(
              id,
              updateItem.Name,
              updateItem.Description,
              updateItem.Price,
              updateItem.Quantity,
              updateItem.Category
              );
          return Results.NoContent();
          });

    //DELETE items/{id}
    groups.MapDelete("/{id}", (int id) =>
        {
        listOfItems.RemoveAll(item => item.Id == id);

        return Results.NoContent();
        });

    return groups;
  }
}
