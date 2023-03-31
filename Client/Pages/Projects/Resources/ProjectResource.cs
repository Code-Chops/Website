// ReSharper disable InconsistentNaming
namespace CodeChops.Website.Client.Pages.Projects.Resources;

public record ProjectResource : Resource<ProjectResource, ResourceProxyEnum>
{
	public static string Title 			=> CreateMember("Projects");
	public static string Error 			=> CreateMember("<br/><br/>⚠️ Currently not available");
	public static string CodeTooling	=> CreateMember("Code tooling");
	public static string Applications	=> CreateMember("Applications");
}
