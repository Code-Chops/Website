namespace CodeChops.Website.RazorComponents.Navigation;

public record struct MenuButtonData
{
    public Action<EventArgs> OnClick { get; init; } 
    public string? FontAwesomeIcon { get; init; }
    public string? Text { get; init; }
    public string? HRef { get; init; }

    public MenuButtonData()
    {
        this.OnClick = _ => { };
        this.FontAwesomeIcon = null;
        this.Text = null;
        this.HRef = null;
    }
}