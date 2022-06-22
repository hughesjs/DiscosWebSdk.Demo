using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DiscosWebSdk.Demo.Blazor;
using DiscosWebSdk.Demo.Blazor.Shared.Services;
using DiscosWebSdk.DependencyInjection;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDiscosServices(builder.Configuration);
builder.Services.AddTransient<IDiscosModelViewService, DiscosModelViewService>();
builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
