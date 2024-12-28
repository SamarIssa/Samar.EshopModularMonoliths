using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Seed;

namespace Shared.Data;

public static class Extentions
{
    public static IApplicationBuilder UseMigration<T>(this IApplicationBuilder app) where T : DbContext
    {
         MigrateDatabaseAsync<T>(app.ApplicationServices).GetAwaiter().GetResult();
        SeedDataAsync<T>(app.ApplicationServices).GetAwaiter().GetResult();

        return app;
    }

    private static async Task SeedDataAsync<T>(IServiceProvider applicationServices) where T : DbContext
    {
        using var scope = applicationServices.CreateScope();

        var services=scope.ServiceProvider.GetServices<IDataSeeder>();
        foreach(var service in services)
        {
            await service.SeedAllAsync();
        }
    }

    private static async Task MigrateDatabaseAsync<T>(IServiceProvider applicationServices) where T : DbContext
    {
        using var scope = applicationServices.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<T>();

        await context.Database.MigrateAsync();
    }
}
