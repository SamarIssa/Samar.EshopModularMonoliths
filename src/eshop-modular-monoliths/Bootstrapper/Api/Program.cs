



var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCarterWithAssemblies(typeof(CatalogModule).Assembly);
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


app.UseBasketModule().
    UseCatalogModule().
    UseOrderingModule();

app.Run();
