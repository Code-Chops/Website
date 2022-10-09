using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Articles;

public record ArticlesResource : Resource<ArticlesResource>
{
	public static string Title => CreateMember("Articles");
}

public record ArticlesResourceNL : Resource<ArticlesResourceNL>
{
	public static string Title { get; } = CreateMember("Artikelen");
}