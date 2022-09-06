namespace GWB.Example.Web.Api.gRPC.ServiceConfiguration;

using Configuration;

internal static class CorsServiceConfiguration
{
    public const string CorsPolicyName = "_corsPolicy";

    public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        var corsSettings = configuration
            .GetSection(nameof(CorsSettings))
            .Get<CorsSettings>();

        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName,
                configurePolicy: policy =>
                {
                    policy.WithOrigins(corsSettings.Origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        return services;
    }
}