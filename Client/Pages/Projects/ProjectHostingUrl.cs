using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.Projects;

public record ProjectHostingUrl : MagicStringEnum<ProjectHostingUrl>
{
	public static ProjectHostingUrl FoodChops { get; } = CreateMember("https://foodchops.azurewebsites.net/");
	public static ProjectHostingUrl Junctions { get; } = CreateMember("https://junctions.azurewebsites.net/");
}
