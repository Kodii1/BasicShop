namespace BasicShop.Api.Endpoints;

public static class CartEndpoints
{

    const string GetCartEndpointsName = "GetCart";

    public static WebApplication MapCartEndpoints(this WebApplication app)
    {

        //GET carts
        // app.MapGet("carts/", () => carts);
        //
        // //GET cart/{id}
        // app.MapGet("carts/{id}", (int id) => carts.Find(cart => cart.Id == id));

        return app;
    }
}
