var builder = WebApplication.CreateBuilder(args);

//Add services to container
builder.Services.AddBasketModule(builder.Configuration).
    AddCatalogModule(builder.Configuration).
    AddOrderingModule(builder.Configuration);

var app = builder.Build();

//Configure the http request pipeline

app.UseBasketModule().
    UseCatalogModule().
    UseOrderingModule();
app.Run();
