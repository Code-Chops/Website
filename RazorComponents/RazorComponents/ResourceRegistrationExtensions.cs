using CodeChops.Website.RazorComponents.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.Website.RazorComponents;

public static class ResourceRegistrationExtensions
{
	public static IServiceCollection AddCountryCache(this IServiceCollection services, IEnumerable<CountryCode> supportedLanguageCodes, CountryCode defaultCountry)
	{
		CountryCodeCache.SetCountries(supportedLanguageCodes, defaultCountry);

		return services;
	}
}
