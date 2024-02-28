using Microsoft.AspNetCore.Components.Web;

namespace CodeChops.Website.Client.Shared.Components.Loading;

public partial class Splash
{
	[Inject] private RenderEnvironment RenderEnvironment { get; init; } = null!;

	[Parameter] public RenderFragment ChildContent { get; set; } = null!;

	private bool IsRenderedOnClient => this.RenderEnvironment is not RenderEnvironment.WebassemblyHost;
	private bool IsLoading { get; set; }
	private bool ShowSplashScreen = true;

	protected override void OnInitialized()
	{
		this.ShowSplashScreen = App.RenderMode is not InteractiveServerRenderMode { Prerender: true };
		this.IsLoading = !this.IsRenderedOnClient;
	}

	protected override void OnAfterRender(bool firstRender)
	{
		Console.WriteLine("OnAfterRender");
		Console.WriteLine(firstRender);

		if ((!firstRender || App.RenderMode is InteractiveServerRenderMode { Prerender: false }) && this.IsLoading)
		{
			this.IsLoading = false;
			this.StateHasChanged();
		}

		base.OnAfterRender(firstRender);
	}
}
