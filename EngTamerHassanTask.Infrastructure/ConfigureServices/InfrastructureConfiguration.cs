namespace EngTamerHassanTask.Infrastructure;

public static class InfrastructureConfiguration
{
    public static void ConfigureInfrastructure(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("EngTamerHassanTaskConnectionString");

        if (!string.IsNullOrEmpty(connectionString))
            builder.Services.ConfigureDb(connectionString);

        Log.Logger = new LoggerConfiguration().WriteTo
           .File(string.Concat(Directory
           .GetCurrentDirectory(), $"\\Logs\\Error.log"),
           rollingInterval: RollingInterval.Hour).CreateLogger();

        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        builder.Services.AddTransient<ITicketRepository, TicketRepository>();
    }
}