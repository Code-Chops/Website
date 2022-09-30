using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Articles;

[DiscoverImplementations]
public partial interface IArticlesResource : IResource<IArticlesResource, IArticlesResourceEnum>
{
	string Title { get; }
}

public record ArticlesResourceEn : MagicStringEnum<ArticlesResourceEn>, IArticlesResource
{
	public string Title { get; } = CreateMember("Articles");
}

public record ArticlesResourceNl : MagicStringEnum<ArticlesResourceNl>, IArticlesResource
{
	public string Title { get; } = CreateMember("Articles");
}