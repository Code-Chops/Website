using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.Projects;

public record ProjectHostingUrl : MagicStringEnum<ProjectHostingUrl>
{
	public static ProjectHostingUrl FoodChops { get; } = CreateMember("/");
	public static ProjectHostingUrl Junctions { get; } = CreateMember("https://junctions.azurewebsites.net/");
}
