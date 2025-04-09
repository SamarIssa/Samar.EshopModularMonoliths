using Keycloak.AuthServices.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMediatRWithAssemblies(typeof(CatalogModule).Assembly, typeof(BasketModule).Assembly);

builder.Services.AddCarterWithAssemblies(typeof(CatalogModule).Assembly, typeof(BasketModule).Assembly);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddMassTransitWithAssemblies(builder.Configuration, typeof(CatalogModule).Assembly, typeof(BasketModule).Assembly);

builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
//Add services to container
builder.Services.AddBasketModule(builder.Configuration).
    AddCatalogModule(builder.Configuration).
    AddOrderingModule(builder.Configuration);


//Register Exception Handler
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

//Configure the http request pipeline

app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });
app.UseAuthentication();
app.UseAuthorization();


app.UseBasketModule().
    UseCatalogModule().
    UseOrderingModule();

app.Run();
