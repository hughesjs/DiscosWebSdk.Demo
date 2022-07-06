using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Components.Forms;
using DiscosWebSdk.Demo.Blazor.Shared.Models.FormData;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.FragmentationEvent;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Pages.SimpleFetching;

public partial class GetMultiple
{
	[Inject]
	private IDiscosClient? Client { get; set; }

	[Inject]
	private ISnackbar? Snackbar { get; set; }

	private bool             _loading;
	private IReadOnlyList<DiscosModelBase?>? _models;
	private bool             _started;

	private async Task LoadData(MultipleFetchFormData data)
	{
		if (Client == null) return;
		_started = true;
		_loading = true;
		try
		{
			_models = await Client.GetMultiple(data.ObjectType);
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
