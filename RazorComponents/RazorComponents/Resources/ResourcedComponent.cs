using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Resources;

public abstract class ResourcedComponent : ComponentBase, IDisposable
{
	public static event Action? LanguageChangedEvent;
	
	protected sealed override void OnInitialized()
	{
		this.OnComponentInitialized();
		LanguageChangedEvent += this.OnLanguageChanged;
	}

	protected virtual void OnComponentInitialized()
	{
	}

	protected static void TriggerLanguageChangedEvent()
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
