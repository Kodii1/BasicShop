using BasicShop.Api.Data;
using BasicShop.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BasicStore");

builder.Services.AddSqlite<BasicStoreContext>(connString);

var app = builder.Build();

app.MapItemEndpoints();
app.MapCartEndpoints();

app.Run();
