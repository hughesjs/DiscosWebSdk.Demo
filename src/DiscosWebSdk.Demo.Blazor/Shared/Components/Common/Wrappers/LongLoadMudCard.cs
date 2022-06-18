using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Wrappers;

public partial class LongLoadMudCard: MudCard
{
	[Parameter]
	public object? ParameterToWaitFor { get; set; }
}
