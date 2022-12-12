using DeepL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CodeChops.Website.Server.Controllers;

public class ProjectsController : Controller
{
	private HttpClient HttpClient { get; }
	private static IMemoryCache MemoryCache { get; } = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromHours(1) });
	private static Translator Translator { get; } = new(authKey: "9b5c886e-ef06-7fc4-6fb5-8ec9e80c06c3:fx");
	
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
			// var targetLanguageCode = new LanguageCode(languageCode);
			//
			// if (targetLanguageCode != LanguageCodeCache.DefaultLanguageCode)
			// 	documentation = (await Translator.TranslateTextAsync(documentation, sourceLanguageCode: LanguageCodeCache.DefaultLanguageCode.GetLanguageCode().ToUpperInvariant(), languageCode)).Text;

			return documentation;
		}));
	}
}
