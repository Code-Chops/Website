using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.Client.Resources;

public abstract class ResourcedComponent : ComponentBase, IDisposable
{
	internal static event Action? LanguageChangedEvent;
	
	protected sealed override void OnInitialized()
	{
		this.OnComponentInitialized();
		LanguageChangedEvent += this.OnLanguageChanged;
	}

	protected virtual void OnComponentInitialized()
	{
	}

	protected void TriggerLanguageChangedEvent()
	{
		LanguageChangedEvent?.Invoke();
	}
	
	private void OnLanguageChanged()
	{
		this.StateHasChanged();
	}
	
	public void Dispose()
	{
		LanguageChangedEvent -= this.OnLanguageChanged;
	}
}