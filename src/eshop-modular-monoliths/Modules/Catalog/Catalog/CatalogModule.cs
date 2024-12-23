using Catalog.Data;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {



        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<CatalogDbContext>(options=>options.UseNpgsql(connectionString));

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {

        return app;
    }
}
