
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Articles;

public record ArticleOverviewResource : Resource<ArticleOverviewResource, ResourceProxyEnum>
{
	public static string Title => CreateMember("Articles");
}

public record ArticleOverviewResourceNL : Resource<ArticleOverviewResourceNL, ResourceProxyEnum>
{
	public static string Title { get; } = CreateMember("Artikelen");
}
