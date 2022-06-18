using System.Reflection;
using DiscosWebSdk.Models.ResponseModels;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Cards;

public partial class DiscosEntityCard: ComponentBase
{
	[Parameter]
	[EditorRequired]
	public DiscosModelBase DiscosModel { get; set; } = null!;

	private Dictionary<string, string?> Properties { get; set; } = new();

	protected override void OnInitialized()
	{
		GetValueProperties();
		base.OnInitialized();
	}

	private void GetValueProperties()
	{
		Type           t     = DiscosModel.GetType();
		PropertyInfo[] props = t.GetProperties();

		Properties = props.ToDictionary(p => p.Name, p => p.GetValue(DiscosModel)?.ToString());
	}
}
	
