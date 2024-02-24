namespace CodeChops.Website.Client.Shared.Components.Loading;

public partial class Splash
{
	[Inject] private RenderEnvironment RenderEnvironment { get; set; } = null!;

	[Parameter] public RenderFragment ChildContent { get; set; } = null!;

	private bool IsRenderedOnClient => this.RenderEnvironment is not RenderEnvironment.WebassemblyHost;
	private bool IsLoading { get; set; } = true;
	private const bool ShowSplashScreen = true;

	protected override void OnInitialized()
	{
		if (this.IsRenderedOnClient)
			this.IsLoading = false;
	}

	protected override void OnAfterRender(bool firstRender)
	{
		if (!firstRender && this.IsLoading)
		{
			this.IsLoading = false;
			this.StateHasChanged();
		}

		base.OnAfterRender(firstRender);
	}
}
