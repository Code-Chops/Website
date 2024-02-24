namespace CodeChops.Website.Client.Shared.Components;

public partial class Box
{
	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
	[Parameter] public string? CodeLanguage { get; set; }
}
