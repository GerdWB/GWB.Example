namespace GWB.Example.ServiceMock._DIRegistration;

using Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCountryServiceMocks(this IServiceCollection services)
    {
        services.AddSingleton<ICountryCommandService, CountryCommandServiceMock>();
        services.AddSingleton<ICountryQueryService, CountryQueryServiceMock>();

        return services;
    }
}