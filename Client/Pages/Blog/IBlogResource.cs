using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.Blog;

[DiscoverImplementations(hasNewableImplementations: true)]
public partial interface IBlogResource : IResource<IBlogResource, IBlogResourceEnum>
{
	string Title { get; }
}

public record BlogResourceEN : MagicStringEnum<BlogResourceEN>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog").Value;
}

public record BlogResourceNL : MagicStringEnum<BlogResourceNL>, IBlogResource
{
	public string Title { get; } = CreateMember("Blog").Value;
}