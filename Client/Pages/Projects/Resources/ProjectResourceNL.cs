namespace CodeChops.Website.Client.Pages.Projects.Resources;

public record ProjectResourceNL : Resource<ProjectResourceNL, ResourceProxyEnum>
{
	public static string Title { get; }			= CreateMember("Projecten");
	public static string Error { get; } 		= CreateMember("<br/><br/>⚠️ Op dit moment niet beschikbaar");
	public static string CodeTooling { get; }	= CreateMember("Code tools");
	public static string Applications { get; }	= CreateMember("Applicaties");
}