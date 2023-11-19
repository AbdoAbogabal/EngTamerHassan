namespace EngTamerHassanTask.Infrastructure;

public static class DbConfiguration
{
    public static void ConfigureDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(e => e.UseSqlServer(connectionString, e => e.MigrationsAssembly("EngTamerHassanTask.Infrastructure").EnableRetryOnFailure())
                                                          .EnableDetailedErrors()
                                                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
    }
}