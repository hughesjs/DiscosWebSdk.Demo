using System.Reflection;
using DiscosWebSdk.Clients;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Cards;

public partial class DiscosEntityCard: ComponentBase
{
	[Parameter]
	public string? DiscosId { get; set; }
	
	[Inject]
	private IDiscosClient? DiscosClient { get; set; }
	
	
	private DiscosModelBase? _discosModel;

	private Dictionary<string, string> GetSimpleProperties()
	{
		if (_discosModel is null) return new();
		Dictionary<string, string> retDict    = new();
		Type                       objectType = _discosModel.GetType();
		IEnumerable<PropertyInfo>  props      = objectType.GetProperties().Where(p => p.Name != "name");
		foreach (PropertyInfo prop in props)
		{
			object? val = prop.GetValue(_discosModel);
			if (val is not null && !(val is string s && string.IsNullOrEmpty(s)))
			{
				retDict.Add(prop.Name, val.ToString() ?? "null");
			}
		}
		return retDict;
	}

	protected override async Task OnInitializedAsync()
	{
		_discosModel = await DiscosClient!.GetSingle<DiscosObject>("1");
		await base.OnInitializedAsync();
	}
}
	
