using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Projects;

public record ProjectResource : Resource<ProjectResource>
{
	public static string Title => CreateMember("Projects");
}

public record ProjectResourceNL : Resource<ProjectResourceNL>
{
	public static string Title { get; }	= CreateMember("Projecten");
}