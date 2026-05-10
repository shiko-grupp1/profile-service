using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileService.Application.Shared;
using ProfileService.Infrastructure.Persistence.Contexts;

namespace ProfileService.Infrastructure.Persistence;

public static class PersistenceRegistrationExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
        }

        //services.AddDbContext<ProfileDbContext>(options =>
        // options.UseSqlServer(connectionString));


        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ProfileDbContext>());



        return services;
    }
}
