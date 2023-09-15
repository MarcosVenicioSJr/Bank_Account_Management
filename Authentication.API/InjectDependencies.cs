using MySql.Data.MySqlClient;

namespace Authentication.API;

public class InjectDependencies
{
    public static IServiceCollection AddInjection(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(x => new MySqlConnection(configuration.GetConnectionString("Default")));

        return services;
    }
}