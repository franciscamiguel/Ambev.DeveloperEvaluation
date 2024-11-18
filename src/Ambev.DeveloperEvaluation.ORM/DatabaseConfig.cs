using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.ORM;

public static class DatabaseConfig
{
    /// <summary>
    ///     Apply Migrations automatically without needing to run update in the CLI
    /// </summary>
    /// <param name="app"></param>
    public static void ApplyMigrations(this WebApplication app)
    {
        var services = app.Services.CreateScope().ServiceProvider;
        var dataContext = services.GetRequiredService<DefaultContext>();
        dataContext.Database.Migrate();
    }
}