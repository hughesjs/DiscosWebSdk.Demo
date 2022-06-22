using AutoFixture;
using DiscosWebSdk.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DiscosWebSdk.Demo.Blazor;
using DiscosWebSdk.Fixtures.AutoFixture.Customizations;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using MudBlazor.Services;
using NSubstitute;
using NSubstitute.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Fixture fixture = new();
fixture.Customize(new DiscosModelFixtureCustomizationNoLinks());

builder.Services.AddTransient(_ =>
							  {
								  IDiscosClient client = Substitute.For<IDiscosClient>();
								  client.GetSingle<DiscosObject>(Arg.Any<string>()).Returns(GetDiscosObject);
								  return client;
							  });

async Task<DiscosObject> GetDiscosObject(CallInfo _)
{
	await Task.Delay(Random.Shared.Next(1000, 5000));
	return fixture.Create<DiscosObject>();
}

builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
