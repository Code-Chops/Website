
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Blog;

public record BlogResource : Resource<BlogResource, ResourceProxyEnum>
{
	public static string Title => CreateMember("Blog");
}

public record BlogResourceNL : Resource<BlogResourceNL, ResourceProxyEnum>
{
	public static string Title { get; } = CreateMember("Blog");
}
