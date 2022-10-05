using CodeChops.ImplementationDiscovery;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Articles;

[DiscoverImplementations]
public partial interface IArticlesResource : IResourceManager<IArticlesResource, IArticlesResourceEnum>
{
	string Title { get; }
}

public record ArticlesResourceEn : Resource<ArticlesResourceEn>, IArticlesResource
{
	public string Title { get; } = CreateMember("Articles");
}

public record ArticlesResourceNl : Resource<ArticlesResourceEn>, IArticlesResource
{
	public string Title { get; } = CreateMember("Artikelen");
}