namespace CodeChops.Website.Client.Shared.Components;

public partial class Code
{
	[Inject] private IJSRuntime JsInterop { get; init; } = null!;

	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
	[Parameter] public string Language { get; set; } = "csharp";

	protected override async Task OnAfterRenderAsync(bool isFirstRender)
	{
		if (isFirstRender)
			await this.JsInterop.InvokeVoidAsync("highlightCode");
	}
}
