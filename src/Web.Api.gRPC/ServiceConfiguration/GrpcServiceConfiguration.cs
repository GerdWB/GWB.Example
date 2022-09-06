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
            options.MaxReceiveMessageSize = 521_288; // 500 KB
            options.MaxSendMessageSize = 521_288; // 500 KB
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
            options.Interceptors.Add<TraceInterceptor>();
        });

        services.AddGrpcReflection();
        return services;
    }
}