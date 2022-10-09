using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.Client.Resources;

public abstract class ResourcedComponent<TLanguageCache> : ComponentBase, IDisposable
	where TLanguageCache : ILanguageCache
{
	internal static event Action<string>? LanguageChangedEvent;
	
	protected override void OnInitialized()
	{
		LanguageChangedEvent += this.OnLanguageChanged;
	}

	protected void TriggerLanguageChangedEvent(string newLanguage)
	{
		LanguageChangedEvent?.Invoke(newLanguage);
	}
	
	private void OnLanguageChanged(string newLanguage)
	{
		TLanguageCache.SetNewLanguage(newLanguage);
		this.StateHasChanged();
	}
	
	public void Dispose()
	{
		LanguageChangedEvent -= this.OnLanguageChanged;
	}
}