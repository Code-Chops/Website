namespace CodeChops.Website.RazorComponents.Navigation;

public record struct MenuButtonData
{
    public Func<EventArgs, MenuButtonData, Task> OnClick { get; init; } 
    public string? FontAwesomeIcon { get; init; }
    public string? Text { get; init; }
    public string? HRef { get; init; }

    public MenuButtonData()
    {
        this.OnClick = (_, _) => Task.CompletedTask;
        this.FontAwesomeIcon = null;
        this.Text = null;
        this.HRef = null;
    }
}