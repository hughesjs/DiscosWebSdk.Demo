using AutoFixture;
using DiscosWebSdk.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DiscosWebSdk.Demo.Blazor;
using DiscosWebSdk.Fixtures.AutoFixture.Customizations;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using MudBlazor.Services;
using NSubstitute;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var     client  = Substitute.For<IDiscosClient>();
Fixture fixture = new();
fixture.Customize(new DiscosModelFixtureCustomizationNoLinks());
DiscosObject obj     = fixture.Create<DiscosObject>();
client.GetSingle<DiscosObject>(Arg.Any<string>()).Returns(Task.Delay(5000).ContinueWith(_ => obj));

builder.Services.AddTransient(_ => client);

builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
