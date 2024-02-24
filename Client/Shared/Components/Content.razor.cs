namespace CodeChops.Website.Client.Shared.Components;

public partial class Content
{
	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
	[Parameter] public string? MaxWidth { get; set; } = "900px";
	[Parameter] public bool IsDocumentation { get; set; }

	private string Guid { get; } = "article" + System.Guid.NewGuid().ToString("N");
}
