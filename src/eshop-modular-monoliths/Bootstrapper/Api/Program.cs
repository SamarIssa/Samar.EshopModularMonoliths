using Carter;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarterWithAssemblies(typeof(CatalogModule).Assembly);
//Add services to container
builder.Services.AddBasketModule(builder.Configuration).
    AddCatalogModule(builder.Configuration).
    AddOrderingModule(builder.Configuration);

var app = builder.Build();

//Configure the http request pipeline

app.MapCarter();

app.UseBasketModule().
    UseCatalogModule().
    UseOrderingModule();
app.Run();
