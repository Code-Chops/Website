using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Resources;

public abstract class ResourcedComponent : ComponentBase, IDisposable
{
	public static event Action? CountryChangedEvent;
	
	protected sealed override void OnInitialized()
	{
		this.OnComponentInitialized();
		CountryChangedEvent += this.OnCountryChanged;
	}

	protected virtual void OnComponentInitialized()
	{
	}

	protected static void TriggerCountryChangedEvent()
	{
		CountryChangedEvent?.Invoke();
	}
	
	private void OnCountryChanged()
	{
		this.StateHasChanged();
	}
	
	public void Dispose()
	{
		CountryChangedEvent -= this.OnCountryChanged;
	}
}
