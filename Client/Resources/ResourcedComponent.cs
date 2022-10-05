using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums.Core;
using CodeChops.Website.Client.Layout;
using CodeChops.Website.Client.Pages.About;
using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.Client.Resources;

public abstract class ResourcedComponent<TBase, TImplementationEnum> : ComponentBase, IDisposable
	where TBase : IResourceManager<TBase, TImplementationEnum> 
	where TImplementationEnum : ImplementationsEnum<TImplementationEnum, TBase>, IMagicEnumCore<TImplementationEnum, DiscoveredObject<TBase>>, new() 
{
	protected TBase Resource { get; set; } = IResourceManager<TBase, TImplementationEnum>.GetResource();
	
	protected override void OnInitialized()
	{
		LanguageSelector.ChangedEvent += this.OnLanguageChanged;
	}
	
	private void OnLanguageChanged()
	{
		this.Resource = IResourceManager<TBase, TImplementationEnum>.GetResource();
		this.StateHasChanged();
	}

	public void Dispose()
	{
		LanguageSelector.ChangedEvent -= this.OnLanguageChanged;
	}
}