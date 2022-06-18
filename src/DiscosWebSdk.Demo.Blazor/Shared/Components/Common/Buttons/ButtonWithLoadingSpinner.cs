using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Buttons;

public partial class ButtonWithLoadingSpinner: ComponentBase
{
	[Parameter]
	public EventCallback<MouseEventArgs> OnClick { get; set; }

	[Parameter]
	public Variant Variant { get; set; } = Variant.Filled;

	[Parameter]
	public Color Color { get; set; } = Color.Primary;

	[Parameter]
	public string LoadingText { get; set; } = "Loading";

	[Parameter]
	public string MainText { get; set; } = string.Empty;


	private bool _loading;


	private async Task OnClickLoadingWrapper(MouseEventArgs arg)
	{
		_loading = true;
		await OnClick.InvokeAsync();
		_loading = false;
	}
}
