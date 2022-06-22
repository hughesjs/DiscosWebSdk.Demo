using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Wrappers;

public partial class LongLoadMudCard : MudCard
{
	[Parameter]
	[EditorRequired]
	public object? ParameterToWaitFor { get; set; }

	[Parameter]
	public bool Started { get; set; } = true;

	[Parameter]
	public int SkeletonLines { get; set; } = 5;
}
