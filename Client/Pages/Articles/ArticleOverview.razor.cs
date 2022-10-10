using CodeChops.Website.Client.Resources;
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Articles;

public record ArticleOverviewResource : Resource<ArticleOverviewResource>
{
	public static string Title => CreateMember("Articles");
}

public record ArticleOverviewResourceNL : Resource<ArticleOverviewResourceNL>
{
	public static string Title { get; } = CreateMember("Artikelen");
}