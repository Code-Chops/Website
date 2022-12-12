using CodeChops.Website.RazorComponents.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.Website.RazorComponents;

public static class ResourceRegistrationExtensions
{
	public static IServiceCollection AddLanguageCodeCache(this IServiceCollection services, IEnumerable<string> supportedLanguageCodes)
	{
		foreach (var code in supportedLanguageCodes)
			LanguageCodeCache.AddLanguageCode(new (code));

		return services;
	}
}
