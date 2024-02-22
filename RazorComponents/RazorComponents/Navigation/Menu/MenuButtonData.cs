using System.Runtime.InteropServices;

namespace CodeChops.Website.RazorComponents.Navigation.Menu;

[StructLayout(LayoutKind.Auto)]
public readonly record struct MenuButtonData()
{
    public Action<EventArgs, MenuButtonData> OnClick { get; init; } = static (_, _) => { };
    public string? FontAwesomeIcon { get; init; } = null;
    public string? Text { get; init; } = null;
    public string? HRef { get; init; } = null;
}
