using System.Reflection;
using DiscosWebSdk.Models.ResponseModels;

namespace DiscosWebSdk.Demo.Blazor.Shared.Services;

public class DiscosModelViewService: IDiscosModelViewService
{
	public Dictionary<string, string> GetSimpleProperties(DiscosModelBase? discosModel)
	{
		if (discosModel is null) return new();
		Dictionary<string, string> retDict    = new();
		Type                       objectType = discosModel.GetType();
		IEnumerable<PropertyInfo>  props      = objectType.GetProperties().Where(p => p.Name != "name");
		foreach (PropertyInfo prop in props)
		{
			object? val = prop.GetValue(discosModel);
			if (val is not null && !(val is string s && string.IsNullOrEmpty(s)))
			{
				retDict.Add(prop.Name, val.ToString() ?? "null");
			}
		}
		return retDict;
	}
}
