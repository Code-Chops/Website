using CodeChops.Website.Client.Resources;
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Blog;

public record BlogResource : Resource<BlogResource>
{
	public static string Title => CreateMember("Blog");
}

public record BlogResourceNL : Resource<BlogResourceNL>
{
	public static string Title { get; } = CreateMember("Blog");
}