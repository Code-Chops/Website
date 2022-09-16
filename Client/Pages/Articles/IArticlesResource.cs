using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.Articles;

[DiscoverImplementations(hasNewableImplementations: true)]
public partial interface IArticlesResource : IResource<IArticlesResource, IArticlesResourceEnum>
{
	string Title { get; }
}

public record ArticlesResourceEn : MagicStringEnum<ArticlesResourceEn>, IArticlesResource
{
	public string Title { get; } = CreateMember("Articles").Value;
}

public record ArticlesResourceNl : MagicStringEnum<ArticlesResourceNl>, IArticlesResource
{
	public string Title { get; } = CreateMember("Articles").Value;
}