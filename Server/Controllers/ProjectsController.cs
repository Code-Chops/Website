using CodeChops.Website.Client.Pages.Projects.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CodeChops.Website.Server.Controllers;

public class ProjectsController : Controller
{
	private HttpClient HttpClient { get; }
	private static IMemoryCache MemoryCache { get; } = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromHours(1) });

	public ProjectsController(HttpClient httpClient)
	{
		this.HttpClient = httpClient;
	}

	[Route("/projects/{project}/documentation")]
	public async Task<IActionResult> GetDocumentationAsync(string project)
	{
		if (String.IsNullOrWhiteSpace(project) || !ProjectOverviewTitleResource.TryGetSingleMember(name: project, out ProjectOverviewTitleResource _))
			return this.BadRequest();

		return this.Ok(await MemoryCache.GetOrCreateAsync(project, async entry =>
		{
			try
			{
				var documentation = await this.HttpClient.GetStringAsync($"https://raw.githubusercontent.com/Code-Chops/{project}/master/README.md");
				entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2);
				return documentation;
			}
			catch (Exception e) when (e is HttpRequestException)
			{
				entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
				return $"Public documentation for project {project} not found on GitHub.";
			}
		}));
	}
}
