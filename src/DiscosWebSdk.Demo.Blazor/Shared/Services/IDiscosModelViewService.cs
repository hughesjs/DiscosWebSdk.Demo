using DiscosWebSdk.Models.ResponseModels;

namespace DiscosWebSdk.Demo.Blazor.Shared.Services;

public interface IDiscosModelViewService
{
	public Dictionary<string, string> GetSimpleProperties(DiscosModelBase? discosModel);
}
