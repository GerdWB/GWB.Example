namespace Web.Api.gRPC.Server.Functional.Tests.TestSetup;

using GWB.Example.Application.Core.Services;
using GWB.Example.ServiceMock;
using Microsoft.Extensions.DependencyInjection;

public class CountryServiceTestFixture : TestingWebAppFactory
{
    protected override void ReConfigureServices(IServiceCollection services)
    {
        base.ReConfigureServices(services);
        services.ReplaceSingleton<ICountryQueryService, CountryQueryServiceMock>();
    }
}