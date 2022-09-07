using GWB.Example.Application.Core._DIRegistration;
using GWB.Example.ServiceMock._DIRegistration;
using GWB.Example.Web.Api.gRPC.ServiceConfiguration;
using GWB.Example.Web.Api.gRPC.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .Enrich.WithCorrelationId()
        .Enrich.FromLogContext()
        .Enrich.WithClientIp()
        .Enrich.WithClientAgent()
        .WriteTo.Console());


// Add services to the container.
builder.Services.ConfigureGrpc();

builder.Services.AddCommandsAndQueries();
builder.Services.AddCountryServiceMocks();
builder.Services.ConfigureCors(builder.Configuration);

builder.Services.AddHttpContextAccessor();
//if (builder.Environment.IsDevelopment())


var app = builder.Build();

app.UseCors(CorsServiceConfiguration.CorsPolicyName);
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