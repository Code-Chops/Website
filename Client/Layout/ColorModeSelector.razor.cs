using CodeChops.Website.RazorComponents.Navigation.Menu;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace CodeChops.Website.Client.Layout;

public partial class ColorModeSelector
{
	[Inject] public IJSRuntime JsRuntime { get; set; } = null!;

	internal static ColorMode Value { get; private set; } = null!;
	private MenuButtonData MenuButtonData { get; set; }

	protected override void OnInitialized()
	{
		this.SetMenuButtonData();
	}

	private void SetMenuButtonData()
	{
		this.MenuButtonData = new MenuButtonData()
		{
			FontAwesomeIcon = Value == ColorMode.DarkMode ? "fa-moon" : "fa-sun",
			OnClick = (e, _) => this.ChangeMode(e)
		};
	}

	private void ChangeMode(EventArgs? e)
	{
		if (e is KeyboardEventArgs { Code: not "Enter" and not "NumpadEnter" })
			return;

		var mode = Value == ColorMode.DarkMode
			? ColorMode.LightMode
			: ColorMode.DarkMode;

		SetMode(mode);
		this.SetMenuButtonData();
		this.StateHasChanged();

		if (this.JsRuntime is not IJSInProcessRuntime inProcessRuntime)
			return;

		inProcessRuntime.InvokeVoid("blazorColorMode.set", Value.Name);
	}

	internal static void SetMode(ColorMode mode)
	{
		Value = mode;
	}
}
