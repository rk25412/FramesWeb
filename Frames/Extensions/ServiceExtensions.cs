using Frames.Repositories;
using Frames.Services;

namespace Frames.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSqlite<AppDbContext>(configuration.GetConnectionString("dbCon"));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureUtilityService(this IServiceCollection services) =>
        services.AddScoped<UtilityService>();
}