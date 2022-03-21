namespace CodeChops.Website.RazorComponents.Helpers;

public static class RazorHelpers
{
    public static string? If(bool predicate, string output)
    {
        return predicate is true ? output : null;
    }

    public static string? If(string? value, string output)
	{
        return value is not null ? output : null;
	}
}