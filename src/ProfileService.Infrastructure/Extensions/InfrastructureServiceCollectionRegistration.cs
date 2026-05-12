using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileService.Application.Profiles;
using ProfileService.Infrastructure.Persistence.Repositories.Profiles;

namespace ProfileService.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionRegistrationExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped<IProfileRepository, ProfileRepository>();

        //services.AddHttpContextAccessor();

        //// configuration hämtar baseUrl från appsettings.dev, som är roten till API:t, inte endpointen
        //services.AddHttpClient<IIdentityServiceClient, IdentityServiceClient>(client =>
        //{
        //    client.BaseAddress = new Uri(configuration["IdentityService:BaseUrl"]!);
        //});


        return services;
    }
}
