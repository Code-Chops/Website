namespace CodeChops.Website.Client.Shared.State;

public interface IStateRedirectService
{
	string? Url { get; }
	void Redirect();
	void ClearUrl();
}
