using Grpc.Net.Client.Web;
using GWB.Example.gRPC;
using GWB.Example.Web.Blazor;
using GWB.Example.Web.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri("https://localhost")
});
builder.Services.AddMudServices();
builder.Services.AddScoped<CountryService>();

builder.Services
    .AddGrpcClient<CountryGrpcService.CountryGrpcServiceClient>(o => { o.Address = new Uri("https://localhost:7106"); })
    .ConfigurePrimaryHttpMessageHandler(() => new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));


await builder.Build().RunAsync();