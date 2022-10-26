namespace CodeChops.Website.RazorComponents.Resources;

public class LanguageCache : ILanguageCache
{
	public static string DefaultLanguageCode => "EN";
	public static string CurrentLanguageCode { get; private set; } = DefaultLanguageCode;
	public static bool CurrentLanguageIsDefault { get; private set; } = true;
	
	public static void SetNewLanguage(string languageCode)
	{
		CurrentLanguageCode = languageCode.ToUpperInvariant();
		CurrentLanguageIsDefault = CurrentLanguageCode == DefaultLanguageCode;
	}
}