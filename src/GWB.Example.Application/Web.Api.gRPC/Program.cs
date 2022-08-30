using GWB.Example.Application.Core._DIRegistration;
using GWB.Example.ServiceMock._DIRegistration;
using GWB.Example.Web.Api.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddCommandsAndQueries();
builder.Services.AddCountryServiceMocks();


var app = builder.Build();

app.MapGrpcService<CountryGrpcService>();

// Configure the HTTP request pipeline.
app.MapGet("/",
    handler: () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();