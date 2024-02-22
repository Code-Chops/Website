using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Navigation.Menu;

public partial class MenuButton
{
	[Parameter] public MenuButtonData Data { get; set; } = new();
	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
	[Inject] private NavigationManager NavigationManager { get; set; } = null!;
}
