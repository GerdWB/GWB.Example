namespace GWB.Example.Web.Api.gRPC.ServiceConfiguration;

using System.IO.Compression;
using Common;
using Grpc.Net.Compression;
using Interceptors;

internal static class GrpcServiceConfiguration
{
    public static IServiceCollection ConfigureGrpc(this IServiceCollection services)
    {
        services.AddGrpc(options =>
        {
            options.MaxReceiveMessageSize = 2097152; // 2 MB
            options.MaxSendMessageSize = 2097152; // 2 MB
            options.CompressionProviders = new List<ICompressionProvider>
            {
                new GzipCompressionProvider(CompressionLevel.Optimal), // gzip
                new BrotliCompressionProvider(CompressionLevel.Optimal) // br
            };
            // grpc accept-encoding, and must match the compression provider declared in CompressionProviders collection
            options.ResponseCompressionAlgorithm = "br";
            options.ResponseCompressionLevel =
                CompressionLevel.Optimal; // compression level used if not set on the provider
            options.EnableDetailedErrors = true;
            options.Interceptors.Add<AddMetaDataInterceptor>();
        });

        services.AddGrpcReflection();
        return services;
    }
}