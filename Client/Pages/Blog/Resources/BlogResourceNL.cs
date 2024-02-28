// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Blog.Resources;

public record BlogResourceNL : Resource<BlogResourceNL, ResourceProxyEnum>
{
	public static string Title { get; } = CreateMember("""
	                                                   Blog
	                                                   """);
}
