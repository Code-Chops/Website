namespace CodeChops.Website.RazorComponents.Helpers;

public static class RazorHelpers
{
    public static string? If(bool predicate, string output)
    {
        return predicate is true ? output : null;
    }
}