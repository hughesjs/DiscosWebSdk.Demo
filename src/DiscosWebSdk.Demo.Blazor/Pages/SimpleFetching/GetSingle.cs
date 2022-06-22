using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Models.FormData;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Pages.SimpleFetching;

public partial class GetSingle : ComponentBase
{
	[Inject]
	private IDiscosClient? Client { get; set; }

	private bool             _loading;
	private DiscosModelBase? _model;
	private bool             _started;

	private async Task LoadData(SimpleFetchFormData data)
	{
		if (Client == null) return;
		_started = true;
		_loading = true;
		_model   = await Client.GetSingle(data.ObjectType, data.ObjectId);
		_loading = false;
	}

}
