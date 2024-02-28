using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace CodeChops.Website.RazorComponents.Navigation.Anchors;

public partial class AnchoredComponent
{
	[Inject] private RenderEnvironment RenderEnvironment { get; init; } = null!;
	[Inject] private IJSRuntime JsRuntime { get; init; } = null!;
	[Inject] private NavigationManager NavigationManager { get; init; } = null!;

	private IDisposable? Registration { get; set; }
	private IJSObjectReference? JsObject { get; set; }

	protected override async Task OnInitializedAsync()
	{
		if (this.RenderEnvironment is RenderEnvironment.WebassemblyHost)
			return;

		this.Registration = this.NavigationManager.RegisterLocationChangingHandler(this.OnLocationChanging);

		this.JsObject = await this.JsRuntime.InvokeAsync<IJSObjectReference>("import",
			"./_content/CodeChops.Website.RazorComponents/Navigation/Anchors/AnchoredComponent.razor.js");

		this.NavigationManager.LocationChanged += this.OnLocationChanged;
	}

	protected override async Task OnAfterRenderAsync(bool isFirstRender)
	{
		if (!isFirstRender)
			await this.ScrollToFragment(new Uri(this.NavigationManager.Uri));
	}

	private async ValueTask OnLocationChanging(LocationChangingContext context)
	{
		if (await this.ScrollToFragment(new Uri(context.TargetLocation)))
			context.PreventNavigation();
	}

	private async void OnLocationChanged(object? _, LocationChangedEventArgs? __)
	{
		await this.ScrollToFragment(new Uri(this.NavigationManager.Uri));
	}

	public new void Dispose()
	{
		this.Registration?.Dispose();
		base.Dispose();
	}

	private async ValueTask<bool> ScrollToFragment(Uri uri)
	{
		var fragment = uri.Fragment;

		if (!fragment.StartsWith('#'))
			return false;

		// Handle text fragment (https://example.org/#test:~:text=foo)
		// https://github.com/WICG/scroll-to-text-fragment/
		var elementId = fragment[1..];
		var index = elementId.IndexOf(":~:", StringComparison.Ordinal);

		if (index > 0)
			elementId = elementId[..index];

		if (!String.IsNullOrEmpty(elementId) && this.JsObject is not null)
			await this.JsRuntime.InvokeVoidAsync("BlazorScrollToId", elementId.ToLowerInvariant());

		return true;
	}
}