using System.Reflection;
using DiscosWebSdk.Clients;
using DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Wrappers;
using DiscosWebSdk.Models.ResponseModels;
using DiscosWebSdk.Models.ResponseModels.DiscosObjects;
using Microsoft.AspNetCore.Components;

namespace DiscosWebSdk.Demo.Blazor.Shared.Components.Common.Cards;

public partial class DiscosEntityCard: LongLoadMudCard
{
	[Parameter]
	public DiscosModelBase? DiscosModel { get; set; }

	private Dictionary<string, string> GetSimpleProperties()
	{
		if (DiscosModel is null) return new();
		Dictionary<string, string> retDict    = new();
		Type                       objectType = DiscosModel.GetType();
		IEnumerable<PropertyInfo>  props      = objectType.GetProperties().Where(p => p.Name != "name");
		foreach (PropertyInfo prop in props)
		{
			object? val = prop.GetValue(DiscosModel);
			if (val is not null && !(val is string s && string.IsNullOrEmpty(s)))
			{
				retDict.Add(prop.Name, val.ToString() ?? "null");
			}
		}
		return retDict;
	}
}
	
