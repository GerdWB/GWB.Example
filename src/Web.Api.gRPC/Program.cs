using System.IO.Compression;
using Grpc.Net.Compression;
using GWB.Example.Application.Core._DIRegistration;
using GWB.Example.ServiceMock._DIRegistration;
using GWB.Example.Web.Api.gRPC.Common;
using GWB.Example.Web.Api.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
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
    options.ResponseCompressionLevel = CompressionLevel.Optimal; // compression level used if not set on the provider
    options.EnableDetailedErrors = true;
});
builder.Services.AddGrpcReflection();

builder.Services.AddCommandsAndQueries();
builder.Services.AddCountryServiceMocks();

const string corsPolicy = "_corsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        configurePolicy: policy =>
        {
            policy.WithOrigins("https://localhost:7247",
                    "http://localhost:5152")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.MapGrpcReflectionService();
app.MapGrpcService<CountryGrpcService>().EnableGrpcWeb();


// Configure the HTTP request pipeline.
app.MapGet("/",
    handler: () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();


// needed for testing, do not remove
public partial class Program
{
}