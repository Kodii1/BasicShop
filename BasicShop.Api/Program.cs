using BasicShop.Api.DTOs;
using BasicShop.Api.Enum;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ItemDto> listOfItems = [
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

List<CartDto> carts = new List<CartDto> {
  new CartDto (1, listOfItems),
  new CartDto (2, new List<ItemDto>(listOfItems)
  {
    new ItemDto(3 ,"Potato", "Frest from ground", 1.0, 10, Category.Wegetables)
  })
};

//GET items
app.MapGet("items/", () => listOfItems).WithName("GetItem");


//GET item/{id}
app.MapGet("items/{id}", (int id) => listOfItems.Find(item => item.Id == id));

//POST items
app.MapPost("items", (CreateItemDto newItem) =>
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
app.MapPut("items/{id}", (int id, UpdateItemDto updateItem) =>
    {
      var index = listOfItems.FindIndex(item => item.Id == id);

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

//DELETE games/{id}

//GET carts
app.MapGet("carts/", () => carts);

//GET cart/{id}
app.MapGet("carts/{id}", (int id) => carts.Find(cart => cart.Id == id));

app.MapGet("/", () => "Hello World!");

app.Run();
