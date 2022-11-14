using System.Collections.Immutable;

namespace CodeChops.Website.RazorComponents.Resources;

public static class CountryCodeCache
{
	/// <summary>
	/// The default 2-letter country code (ISO 3166-1 alpha-2) in uppercase invariant culture.
	/// </summary>
	public static CountryCode DefaultCountryCode => _defaultCountryCode ?? throw new InvalidOperationException("Trying to retrieve default country code but it has not been set.");
	private static CountryCode? _defaultCountryCode;
	
	/// <summary>
	/// Get the 2-letter country code (ISO 3166-1 alpha-2) in uppercase invariant culture.
	/// </summary>
	public static CountryCode CurrentCountryCode { get; private set; }
	public static bool CurrentCountryCodeIsDefault { get; private set; } = true;
	public static SupportedCountryCodes SupportedCountryCodes { get; private set; }

	internal static void SetCountries(IEnumerable<CountryCode> supportedCountryCodes, CountryCode defaultCountryCode)
	{
		if (SupportedCountryCodes.Count > 0)
			throw new InvalidOperationException("Supported country codes are already added.");
			
		_defaultCountryCode = defaultCountryCode;
		
		supportedCountryCodes = supportedCountryCodes
			.Append(defaultCountryCode)
			.Distinct();

		SupportedCountryCodes = new(supportedCountryCodes.ToImmutableList());
		
		SetCurrentCountryCode(defaultCountryCode);
	}
	
	public static void SetCurrentCountryCode(CountryCode countryCode)
	{
		if (SupportedCountryCodes.Count == 0)
			throw new InvalidOperationException("Can't set new country code: no supported country codes have been added.");

		if (!SupportedCountryCodes.Contains(countryCode))
			throw new InvalidOperationException($"Trying to set current {countryCode} but it's not configured as a supported one.");
		
		CurrentCountryCode = countryCode;
		CurrentCountryCodeIsDefault = CurrentCountryCode == DefaultCountryCode;
	}
}
