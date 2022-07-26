namespace CodeChops.Website.RazorComponents.Navigation;

public record MenuButtonData
{
    public string? FontAwesomeIcon { get; set; }
    public string Text { get; init; } = null!;
    public string? HRef { get; set; }
}