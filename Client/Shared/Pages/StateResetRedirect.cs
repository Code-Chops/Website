namespace CodeChops.Website.Client.Shared.Pages;

[Route(Route)]
public class RedirectForState : ComponentBase
{
    public const string Route = "/state-reset-redirect";

    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    [SupplyParameterFromQuery(Name = nameof(Url))] public string? Url { get; init; }

    protected override void OnInitialized()
    {
        var uri = Uri.UnescapeDataString(this.Url ?? "/");
        this.NavigationManager.NavigateTo(uri, forceLoad: false);

        base.OnInitialized();
    }

    public static void Redirect(NavigationManager navigationManager)
    {
        var url = $"{Route}?{nameof(Url)}={new Uri(navigationManager.Uri).PathAndQuery}";
        navigationManager.NavigateTo(url);
    }
}
