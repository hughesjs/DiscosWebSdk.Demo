using System.Reflection;
using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Wrappers;
using DiscosWebSdk.Demo.Blazor.Shared.Services;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Cards;

public partial class DiscosEntityCard: LongLoadMudCard
{
	[Parameter]
	public DiscosModelBase? DiscosModel { get; set; }

	[Inject]
	private IDiscosModelViewService? ModelViewService { get; set; }
}
	
