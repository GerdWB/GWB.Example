namespace Web.Api.gRPC.Server.Functional.Tests.TestSetup;

using Microsoft.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void ReplaceSingleton<TServiceInterface, TNewServiceImplementation>(this IServiceCollection services)
        where TServiceInterface : class
        where TNewServiceImplementation : class, TServiceInterface
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TServiceInterface));
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        services.AddSingleton<TServiceInterface, TNewServiceImplementation>();
    }
}