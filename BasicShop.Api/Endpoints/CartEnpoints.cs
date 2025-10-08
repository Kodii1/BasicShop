namespace BasicShop.Api.Endpoints;

using BasicShop.Api.DTOs;
using BasicShop.Api.Enum;

public static class CartEndpoints{

  const string GetCartEndpointsName = "GetCart";

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
  private static readonly List<CartDto> carts = new List<CartDto> {
  new CartDto (1, listOfItems),
  new CartDto (2, new List<ItemDto>(listOfItems)
  {
    new ItemDto(3 ,"Potato", "Frest from ground", 1.0, 10, Category.Wegetables)
  })
};

  public static WebApplication MapCartEndpoints(this WebApplication app){

    //GET carts
    app.MapGet("carts/", () => carts);

    //GET cart/{id}
    app.MapGet("carts/{id}", (int id) => carts.Find(cart => cart.Id == id));

    return app;
  }
}
