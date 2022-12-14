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
		return this.Ok(await MemoryCache.GetOrCreateAsync(project, async entry =>
		{
			entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
			var documentation = await this.HttpClient.GetStringAsync($"https://raw.githubusercontent.com/Code-Chops/{project}/master/README.md");

			return documentation;
		}));
	}
}
