using System.Runtime.InteropServices;

namespace CodeChops.Website.RazorComponents.Navigation.Menu;

[StructLayout(LayoutKind.Auto)]
public readonly record struct MenuButtonData
{
    public Action<EventArgs, MenuButtonData> OnClick { get; init; }
    public string? FontAwesomeIcon { get; init; }
    public string? Text { get; init; }
    public string? HRef { get; init; }

    public MenuButtonData()
    {
        this.OnClick = static (_, _) => { };
        this.FontAwesomeIcon = null;
        this.Text = null;
        this.HRef = null;
    }
}
