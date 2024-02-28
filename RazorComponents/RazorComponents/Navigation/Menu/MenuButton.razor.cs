using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Navigation.Menu;

public partial class MenuButton
{
	[Inject] private NavigationManager NavigationManager { get; init; } = null!;

	[Parameter] public MenuButtonData Data { get; set; } = new();
	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
}
