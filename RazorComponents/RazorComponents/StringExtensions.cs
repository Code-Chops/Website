namespace CodeChops.Website.RazorComponents;

public static class StringExtensions
{
	/// <summary>
	/// Is true if the resource contains text (and not only whitespace).
	/// </summary>
	public static bool ContainsText(this string value) => !String.IsNullOrWhiteSpace(value); 
}
