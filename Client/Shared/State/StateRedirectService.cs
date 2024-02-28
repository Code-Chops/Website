using CodeChops.Website.Client.Shared.Pages;

namespace CodeChops.Website.Client.Shared.State;

public sealed class StateRedirectService(NavigationManager navigationManager) : IStateRedirectService
{
	public string? Url { get; private set; }

	public void Redirect()
	{
		this.Url = new Uri(navigationManager.Uri).PathAndQuery;

		navigationManager.NavigateTo(RedirectForState.Route, forceLoad: false);
	}

	public void ClearUrl()
	{
		this.Url = null;
	}
}
