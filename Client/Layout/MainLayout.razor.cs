using CodeChops.Website.Client.Pages.About.Resources;
using CodeChops.Website.Client.Pages.Home.Resources;

namespace CodeChops.Website.Client.Layout;

public partial class MainLayout
{
	[Inject] public NavigationManager NavigationManager { get; init; } = null!;
	[Inject] protected RenderEnvironment RenderEnvironment { get; init; } = null!;

	private MenuBar? MenuBar { get; set; }
	private bool ShowTitle => this.RenderEnvironment is not RenderEnvironment.WebassemblyHost;
	private static bool IsDarkMode => ColorModeSelector.Value == ColorMode.DarkMode;

	private static MenuButtonData[] ButtonsGetter() =>
	[
		new() { HRef = "/", Text = HomeResource.Title },
		new() { HRef = "/projects", Text = ProjectResource.Title },
		new() { HRef = "/about", Text = AboutResource.Title }
	];
}
