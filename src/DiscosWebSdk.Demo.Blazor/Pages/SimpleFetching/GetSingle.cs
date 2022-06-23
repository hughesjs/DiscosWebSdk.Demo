using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Models.FormData;
using DiscosWebSdk.Models.ResponseModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Pages.SimpleFetching;

public partial class GetSingle : ComponentBase
{
	[Inject]
	private IDiscosClient? Client { get; set; }

	[Inject]
	private ISnackbar? Snackbar { get; set; }

	private bool             _loading;
	private DiscosModelBase? _model;
	private bool             _started;

	private async Task LoadData(SimpleFetchFormData data)
	{
		if (Client == null) return;
		_started = true;
		_loading = true;
		try
		{
			_model = await Client.GetSingle(data.ObjectType, data.ObjectId);
		}
		catch (Exception e)
		{
			if (Snackbar is not null)
			{
				Snackbar.Clear();
				Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
				Snackbar.Add(e.Message, Severity.Error);
			}
		}
		finally
		{
			_loading = false;
		}
	}
}
