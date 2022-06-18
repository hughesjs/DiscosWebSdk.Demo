using DiscosWebSdk.Clients;
using DiscosWebSdk.Models.ResponseModels.FragmentationEvent;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Pages.SimpleFetching;

public partial class GetMultiple
{
	[Inject]
	private IDiscosClient DiscosClient { get; set; }

	private IReadOnlyList<FragmentationEvent> FragmentationEvents { get; set; }
	
	private bool _loading { get; set; }

	private async Task UpdateModel()
	{
		_loading            = true;
		FragmentationEvents = await DiscosClient.GetMultiple<FragmentationEvent>();
		_loading            = false;
	}
}
