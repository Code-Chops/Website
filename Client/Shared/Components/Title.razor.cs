namespace CodeChops.Website.Client.Shared.Components;

public partial class Title
{
	[Parameter] public string? Value { get; set; }
	[Parameter] public bool ShowTitle { get; set; } = true;
}
