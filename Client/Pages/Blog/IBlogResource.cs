using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Blog;

[DiscoverImplementations]
public partial interface IBlogResource : IResource<IBlogResource, IBlogResourceEnum>
{
	string Title { get; }
}

public record BlogResourceEN : MagicStringEnum<BlogResourceEN>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog");
}

public record BlogResourceNL : MagicStringEnum<BlogResourceNL>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog");
}