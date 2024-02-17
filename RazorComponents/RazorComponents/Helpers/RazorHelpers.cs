namespace CodeChops.Website.RazorComponents.Helpers;

public static class RazorHelpers
{
    public static string? If(bool predicate, string output)
    {
        return predicate ? output : null;
    }

    public static T? If<T>(bool predicate, T output)
    {
	    return predicate ? output : default;
    }

    public static string? IfNotNull(string? value, string output)
	{
        return value is not null ? output : null;
	}
}
