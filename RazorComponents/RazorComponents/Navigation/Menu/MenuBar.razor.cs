using CodeChops.Website.RazorComponents.Helpers;
using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Navigation.Menu;

public partial class MenuBar
{
	[Parameter] public string Title { get; set; } = null!;
	[Parameter] public FlexColor BackgroundColor { get; set; }
	[Parameter] public FlexColor AccentColor { get; set; }
	[Parameter] public FlexColor TextColor { get; set; }
	[Parameter] public FlexColor HRefColor { get; set; }
	[Parameter] public string? FontFamily { get; set; }
	[Parameter] public string FontSize { get; set; } = "40px";
	[Parameter] public string? CustomToggleImage { get; set; }
	[Parameter] public string? LogoPath { get; set; }
	[Parameter] public int Height { get; set; } = 80;
	[Parameter] public bool ShowLogo { get; set; } = true;
	[Parameter] public bool ShowTitle { get; set; } = true;
	[Parameter] public Func<MenuButtonData[]>? ButtonsGetter { get; set; }
	[Parameter] public int CollapseWidth { get; set; } = 720;
	[Parameter] public RenderFragment ChildContent { get; set; } = null!;
	[Parameter] public bool FadeOut { get; set; } = true;

	private bool IsCollapsed { get; set; } = true;

	private void Toggle()
	{
		this.IsCollapsed = !this.IsCollapsed;

		this.StateHasChanged();
	}

	public void Collapse()
	{
		if (!this.IsCollapsed)
			this.Toggle();
	}

	public void OnClickButton(EventArgs e, MenuButtonData button)
	{
		this.Collapse();
		button.OnClick(e, button);
	}
}