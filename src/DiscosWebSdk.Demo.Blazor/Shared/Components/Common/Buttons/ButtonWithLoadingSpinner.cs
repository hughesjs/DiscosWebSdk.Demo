using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Buttons;

public partial class ButtonWithLoadingSpinner: MudButton
{
	[Parameter]
	public string LoadingText { get; set; } = "Loading";

	[Parameter]
	public string MainText { get; set; } = string.Empty;

	[Parameter]
	public bool Loading { get; set; }
}
