using CodeChops.Website.Client.Shared;

namespace CodeChops.Website.Client.Pages.Projects.Details;

[Route(Route)]
public partial class ProjectDetailsPage : AnchoredComponent
{
	public const string Route = "/projects/{project}/";

	[Inject] private NavigationManager NavigationManager { get; init; } = null!;
	[Inject] private IJSRuntime JsInterop { get; init; } = null!;
	[Inject] private HttpClient HttpClient { get; init; } = null!;

	[Parameter] public required string Project { get; set; } = null!;

	public string? Title { get; private set; }
	public string? DocumentationText { get; private set; }

	public string LinkName => $"{GeneralResource.GitHub} - {this.Project}";

	public static string? OnlyEnglishText
		=> GeneralResource.OnlyInEnglish.ContainsText()
			? $" {GeneralResource.OnlyInEnglish}"
			: null;

	private CancellationTokenSource CancellationTokenSource { get; } = new();

	protected override async Task OnInitializedAsync()
	{
		this.HttpClient.BaseAddress = new(this.NavigationManager.BaseUri);
		this.Title = ProjectOverviewTitleResource.GetSingleMember(this.Project);

		var pipeline = new MarkdownPipelineBuilder()
			.UsePipeTables()
			.UseGridTables()
			.UseAdvancedExtensions()
			.UseEmojiAndSmiley()
			.Build();

		var documentationFromServer = await this.HttpClient.GetStringAsync($"/projects/{this.Project}/documentation/",
			this.CancellationTokenSource.Token);

		this.DocumentationText = Markdown.ToHtml(documentationFromServer, pipeline);

		await base.OnInitializedAsync();
	}

	protected override async Task OnAfterRenderAsync(bool isFirstRender)
	{
		if (!isFirstRender)
			await this.JsInterop.InvokeVoidAsync("highlightCode");

		await base.OnAfterRenderAsync(isFirstRender);
	}

	public new void Dispose()
	{
		this.CancellationTokenSource.Cancel();
		this.CancellationTokenSource.Dispose();
		base.Dispose();
	}
}
