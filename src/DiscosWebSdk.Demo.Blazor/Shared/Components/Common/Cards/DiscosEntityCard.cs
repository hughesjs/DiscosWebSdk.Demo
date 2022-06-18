using DiscosWebSdk.Clients;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Cards;

public partial class DiscosEntityCard: ComponentBase
{
	[Parameter]
	public string DiscosId { get; set; }
	
	[Inject]
	private IDiscosClient _discosClient { get; set; }
	
	
	private DiscosModelBase? _discosModel;

	protected override async Task OnInitializedAsync()
	{
		_discosModel = await _discosClient.GetSingle<DiscosObject>("1");
		await base.OnInitializedAsync();
	}

}
	
