using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace CodeChops.Website.RazorComponents.Navigation.Paging;

public partial class Paginator : MudComponentBase
{
    [Inject] public NavigationManager NavManager { get; set; } = null!;

    [CascadingParameter] public TableContext? Context { get; set; }
    public virtual MudTableBase? Table => this.Context?.Table;

    /// <summary>
    /// This callback is called when a numbered button is clicked in the paging component.
    /// The provided parameter is the page number that is changed to (1 based).
    /// </summary>
    [Parameter] public EventCallback<ushort> OnPageChangeCallback { get; set; }

    /// <summary>
    /// When this is not null, whenever a new page is selected the component will automatically navigate to the page with the provided type.
    /// </summary>
    [Parameter] public Type? PageNavigationType { get; set; }

    /// <summary>
    /// Set to False to show the part of the pager which allows to change the page size.
    /// </summary>
    [Parameter] public bool DisablePageSizeSelection { get; set; } = true;

    /// <summary>
    /// Define a list of available page size options for the user to choose from
    /// </summary>
    [Parameter] public ushort[] PageSizeOptions { get; set; } = new ushort[] { 10, 25, 50, 100 };

    /// <summary>
    /// Format string for the display of the current page, which you can localize to your language. Available variables are:
    /// {first_item}, {last_item} and {all_items} which will be replaced with the indices of the page's first and last item as well as the total number of items.
    /// Default: "{first_item}-{last_item} of {all_items}" which is transformed into "0-25 of 77". 
    /// </summary>
    [Parameter] public string InfoFormat { get; set; } = "Showing items {first_item}-{last_item} of {all_items}";

    /// <summary>
    /// Indicates if the items text should contain an indication that more than the result of the search/filter/query are currently in the table (adds a + to the item count).
    /// </summary>
    [Parameter] public bool HasMoreResultsThanDisplayed { get; set; }

    /// <summary>
    /// Text to be dislayed to inform the user of the selected items in the table.
    /// </summary>
    [Parameter] public string? SelectionText { get; set; }

    /// <summary>
    /// The localizable "Rows per page:" text.
    /// </summary>
    [Parameter] public string RowsPerPageString { get; set; } = "Rows per page: ";

    /// <summary>
    /// Used to set the initial page whenever the component is refreshed. 
    /// This could be coupled with an url parameter for example.
    /// This property is 1 based (no page 0). 
    /// </summary>
    [Parameter]
    public int PageNumber
    {
        get => this.CurrentPageIndex + 1;
        set => this.CurrentPageIndex = value < 1 ? 0 : value - 1;
    }

    /// <summary>
    /// Provides a zero based index representing the current page 
    /// </summary>
    public virtual int CurrentPageIndex { 
        get => this.Table is null ? 0 : this.Table.CurrentPage;
        set
        {
            // Sometimes this is called method before the table has been set through the cascading parameters.
            if (this.Table is null) return;
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
            this.Table!.CurrentPage = value;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
        }
    }

    /// <summary>
    /// Provides the total number of items in the tables collection
    /// </summary>
    public virtual int TotalItems => this.Table?.GetFilteredItemsCount() ?? 0;

    /// <summary>
    /// Provides the currently set rows per page.
    /// </summary>
    public virtual int PageSize => this.Table?.RowsPerPage ?? 15;

    public ushort LastPageNumber => (ushort)Math.Ceiling((double)this.TotalItems / this.PageSize);

    public bool ShowFirstButton => this.CurrentPageIndex > 2 && this.LastPageNumber > 5;
    public bool ShowLastButton => this.LastPageNumber > this.CurrentPageIndex + 3 && this.LastPageNumber > 5;

    protected string Classname =>
        new CssBuilder("mud-table-pagination-toolbar")
            .AddClass(this.Class)
            .Build();

    /// <summary>
    /// Used to display the table data information based on an input format, replacing {first_item}, {last_item} and {all_items} with calculated values.
    /// </summary>
    private string Info => this.Table is null ? "There is no Table" : this.InfoFormat
        .Replace("{first_item}", $"{Math.Min(this.CurrentPageIndex * this.PageSize + 1, this.TotalItems)}")
        .Replace("{last_item}", $"{Math.Min((this.CurrentPageIndex + 1) * this.PageSize, this.TotalItems)}")
        .Replace("{all_items}", $"{this.TotalItems}" + (this.HasMoreResultsThanDisplayed ? "+" : ""));

    public IReadOnlyCollection<ushort> GetButtons()
    {
        var result = new List<ushort>();
        if (!this.ShowFirstButton)
        {
            for (var i = 1; i <= this.LastPageNumber && i <= 5; i++)
                result.Add((ushort)i);
        }
        else if (!this.ShowLastButton)
        {
            for (var i = this.LastPageNumber; i > 0 && i > this.LastPageNumber - 5; i--)
                result.Add(i);

            result.Reverse();
        }
        else
        {
            for (var i = this.PageNumber - 2; i <= this.PageNumber + 2; i++)
                result.Add((ushort)i);
        }
        return result;
    }


    public void OnPageChange(ushort pageNumber)
    {
        this.PageNumber = pageNumber;

        this.OnPageChangeCallback.InvokeAsync((ushort)this.PageNumber);

        if (this.PageNavigationType is not null)
            this.NavManager.NavigateToPage(retainQueryString: true, page: this.PageNavigationType, subroute: this.PageNumber.ToString());
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (this.Context != null)
        {
            this.Context.HasPager = true;
            this.Context.PagerStateHasChanged = this.StateHasChanged;
        }
    }
    private void SetRowsPerPage(ushort size)
    {
        this.Table?.SetRowsPerPage(size);
    }
}