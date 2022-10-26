namespace CodeChops.Website.RazorComponents.Resources;

public interface ILanguageCache
{
	public static abstract string DefaultLanguageCode { get; }
	
	/// <summary>
	/// Get the 2-letter (ISO 639-1) language code in uppercase invariant culture.
	/// </summary>
	public static abstract string CurrentLanguageCode { get; }
	
	public static abstract bool CurrentLanguageIsDefault { get; }
	
	public static abstract void SetNewLanguage(string languageCode);
}