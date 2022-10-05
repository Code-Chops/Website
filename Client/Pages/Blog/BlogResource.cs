using CodeChops.ImplementationDiscovery;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Blog;

[DiscoverImplementations]
public partial interface IBlogResource : IResourceManager<IBlogResource, IBlogResourceEnum>
{
	string Title { get; }
}

public record BlogResourceEN : Resource<BlogResourceEN>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog");
}

public record BlogResourceNL : Resource<BlogResourceNL>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog");
}