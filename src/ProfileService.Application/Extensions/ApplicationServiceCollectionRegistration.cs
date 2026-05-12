using Microsoft.Extensions.DependencyInjection;
using ProfileService.Application.Profiles;

namespace ProfileService.Application.Extensions;

public static class ApplicationServiceCollectionRegistrationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<IProfileService, ProfileService>();

        return services;
    }
}
