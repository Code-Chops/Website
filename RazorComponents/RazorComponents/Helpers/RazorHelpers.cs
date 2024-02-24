namespace CodeChops.Website.RazorComponents.Helpers;

public static class RazorHelpers
{
    public static T? If<T>(bool predicate, T output)
    {
	    return predicate ? output : default;
    }

    public static string? IfNotNull<T>(T? value, string output)
	{
        return value is not null ? output : default;
	}
}
