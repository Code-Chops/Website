using CodeChops.DomainModeling.Serialization;

namespace CodeChops.Website.Client.Pages.Projects;

public partial class ProjectThumbnail
{
	[Inject] public IJSRuntime JsRuntime { get; init; } = null!;

	[Parameter] public required string Code { get; set; } = null!;
	[Parameter] public required string Title { get; set; } = null!;
	[Parameter] public required MarkupString Text { get; set; }
	[Parameter] public required string ImagePath { get; set; } = null!;
	[Parameter] public required bool IsImplemented { get; set; }

	/// <summary>
	/// Should be a relative path when <see cref="IsDocumentation"/> is enabled, otherwise an absolute path.
	/// </summary>
	[Parameter] public string? Path { get; set; }

	[Parameter] public bool IsDocumentation { get; set; } = true;

	private string ImageId { get; set; } = null!;
	private string ThumbnailId { get; set; } = null!;

	protected override void OnInitialized()
	{
		this.ImageId = $"Image{this.Code}";
		this.ThumbnailId = $"Thumbnail{this.Code}";
	}

	protected override async Task OnAfterRenderAsync(bool isFirstRender)
	{
		await this.JsRuntime.InvokeVoidAsync("addThumbnailVisualizations", this.ImageId, this.ThumbnailId);
	}

	private string? GetPath()
	{
		if (!this.IsImplemented)
			return null;

		return this.IsDocumentation
			? this.Path?.Write($"/projects/{this.Path}/")
			: this.Path;
	}
}
