using DiscosWebSdk.Demo.Blazor.Shared.Models.FormData;
using DiscosWebSdk.Demo.Blazor.Shared.Models.Misc;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Forms;

public partial class MultipleFetchForm : MudForm
{
	[Parameter]
	public EventCallback<MultipleFetchFormData> FormSubmitted { get; set; }

	[Parameter] 
	public bool Loading { get; set; }
	
	private bool _isSuccess;

	private TypeWrapper _selectedType = new(typeof(DiscosObject));

	private void Submit()
	{
		if (!_isSuccess) return;
		FormSubmitted.InvokeAsync(new(_selectedType.Type));
	}
}