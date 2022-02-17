namespace CodeChops.Website.RazorComponents.Navigation;

public record MenuButtonData
{
    public string FontAwesomeIcon { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string HRef { get; set; }
}