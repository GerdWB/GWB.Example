using GWB.Example.Application.Core.Services;
using GWB.Example.Web.Blazor;
using GWB.Example.Web.Blazor.Mock;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSingleton<ICountryQueryService, CountryQueryServiceMock>();


await builder.Build().RunAsync();