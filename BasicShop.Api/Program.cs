using BasicShop.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapItemEndpoints();
app.MapCartEndpoints();

app.Run();
