namespace GWB.Example.ServiceMock._DIRegistration;

using Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
    {
        services.AddScoped<ICountryCommandService, CountryCommandServiceMock>();
        services.AddScoped<ICountryQueryService, CountryQueryServiceMock>();

        return services;
    }
}