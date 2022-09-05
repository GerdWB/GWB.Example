using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GWB.Example.Web.Blazor;
using GWB.Example.Web.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost")
});
builder.Services.AddMudServices();
builder.Services.AddScoped<CountryService>();


builder.Services
    .AddSingleton(services =>
    {
        var config = services.GetRequiredService<IConfiguration>();
        var backEndUrl = config["gRPC:countryServices"];
        var httpHandler =
            new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
        return GrpcChannel.ForAddress(backEndUrl,
            new GrpcChannelOptions { HttpHandler = httpHandler, MaxReceiveMessageSize = null });
    });

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        configurePolicy: builder =>
//        {
//            builder
//                .AllowAnyOrigin()
//                .AllowAnyMethod()
//                .AllowAnyHeader();
//        });
//});


await builder.Build().RunAsync();