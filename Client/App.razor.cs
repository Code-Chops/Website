using Microsoft.AspNetCore.Components.Web;

namespace CodeChops.Website.Client;

public partial class App : IDisposable
{
	public static IComponentRenderMode RenderMode { get; } = new InteractiveWebAssemblyRenderMode(prerender: true);

	private LanguageScope? LanguageScope { get; set; }

	protected override void OnInitialized()
	{
		this.LanguageScope = new LanguageScope(new LanguageCode("en-US"));

		base.OnInitialized();
	}

	public void Dispose()
	{
		this.LanguageScope?.Dispose();
	}
}
