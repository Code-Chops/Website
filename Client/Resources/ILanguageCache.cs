namespace CodeChops.Website.Client.Resources;

public interface ILanguageCache
{
	/// <summary>
	/// Get the 2-letter (ISO 639-1) language code in uppercase invariant culture.
	/// </summary>
	public static abstract string GetLanguageCode();
}