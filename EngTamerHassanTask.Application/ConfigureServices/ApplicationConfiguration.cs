namespace EngTamerHassanTask.Application;

public static class ApplicationConfiguration
{
    public static void ConfigureApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(ApplicationConfiguration).GetTypeInfo().Assembly);
    }
}