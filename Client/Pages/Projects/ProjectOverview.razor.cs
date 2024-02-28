using Microsoft.AspNetCore.Components.Authorization;

namespace CodeChops.Website.Client.Pages.Projects;

public partial class ProjectOverview
{
	[CascadingParameter] private Task<AuthenticationState>? AuthenticationState { get; set; }

	private string Username { get; set; } = null!;
	private static List<string> RandomProjectNames { get; }
	private static Dictionary<bool, List<Dictionary<string, object>>> ParametersByProjectType { get; set; } = null!;

	private static IEnumerable<string> ImplementedProjects { get; } =
	[
		nameof(ProjectOverviewTitleResource.GenericMath),
		nameof(ProjectOverviewTitleResource.DomainModeling),
		nameof(ProjectOverviewTitleResource.MagicEnums),
		nameof(ProjectOverviewTitleResource.ImplementationDiscovery),
		nameof(ProjectOverviewTitleResource.Geometry),
		nameof(ProjectOverviewTitleResource.SourceGenerationUtilities),
		nameof(ProjectOverviewTitleResource.LightResources),
		nameof(ProjectOverviewTitleResource.Crossblade),
		nameof(ProjectOverviewTitleResource.FoodChops)
	];

	static ProjectOverview()
	{
		var random = new Random();
		RandomProjectNames = ProjectOverviewTitleResource.GetValues().OrderBy(_ => random.Next()).ToList();
	}

	protected override void OnComponentInitialized()
	{
		CreateView();

		this.LanguageChangedEvent += CreateView;

		base.OnComponentInitialized();
	}

	protected override async Task OnInitializedAsync()
	{
		if (this.AuthenticationState is not null)
		{
			var state = await this.AuthenticationState;

			this.Username = state?.User?.Identity?.Name ?? "";
		}

		await base.OnInitializedAsync();
	}

	private static void CreateView()
	{
		ParametersByProjectType = ProjectOverviewTitleResource
			.GetMembers()
			.OrderBy(member => RandomProjectNames.IndexOf(member.Name))
			.Select(member => new Dictionary<string, object>()
			{
				["Code"] = member.Name,
				["Title"] = member.Value!,
				["Text"] = (MarkupString)ProjectOverviewTextResource.GetSingleMember(member.Name),
				["ImagePath"] = $"images/projects/{member.Name}.png",
				["Path"] = ProjectHostingUrl.TryGetSingleMember(member.Name, out ProjectHostingUrl? hostingUrl)
					? hostingUrl.Value!
					: member.Name,
				["IsDocumentation"] = hostingUrl is null,
				["IsImplemented"] = ImplementedProjects.Contains(member.Name),
			})
			.ToList()
			.GroupBy(parametersOfProject => (bool)parametersOfProject["IsDocumentation"])
			.ToDictionary(group => group.Key, group => group.ToList());
	}
}