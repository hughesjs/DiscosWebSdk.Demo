using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Models.FormData;
using DiscosWebSdk.Demo.Blazor.Shared.Models.Misc;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.SimpleFetching.Forms;

public partial class SimpleFetchForm : MudForm
{
	[Parameter]
	public EventCallback<SimpleFetchFormData> FormSubmitted { get; set; }

	[Parameter]
	public bool Loading { get; set; }

	private bool        _isSuccess;
	private TypeWrapper _selectedType = new(typeof(DiscosObject));
	private string      _objectId     = string.Empty;

	private void Submit()
	{
		if (!_isSuccess) return;
		FormSubmitted.InvokeAsync(new() {ObjectId = _objectId, ObjectType = _selectedType.Type});
	}
}
