namespace CodeChops.Website.Client.Resources;

public class LanguageCache : ILanguageCache
{
	private static CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;
	public static string GetLanguageCode() => Culture.TwoLetterISOLanguageName;

	public static void SetNewLanguage(CultureInfo culture)
	{
		Culture = culture;
	}
}