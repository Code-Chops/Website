namespace CodeChops.Website.Client.Pages.Blog.Resources;

public record BlogResource : Resource<BlogResource, ResourceProxyEnum>
{
	public static string Title	=> CreateMember("""
	                          	                Blog
	                          	                """);
}
