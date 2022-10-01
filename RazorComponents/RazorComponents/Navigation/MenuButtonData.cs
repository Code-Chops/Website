using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Navigation;

public record MenuButtonData
{
    public Action<EventArgs> OnClick { get; init; } = null!;
    public string? FontAwesomeIcon { get; init; }
    public string Text { get; init; } = null!;
    public string? HRef { get; init; }
}