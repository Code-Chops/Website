using CodeChops.ImplementationDiscovery;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Projects;

[DiscoverImplementations]
public partial interface IProjectResource : IResourceManager<IProjectResource, IProjectResourceEnum>
{
	string Title { get; }
}

public record ProjectResourceEN : Resource<ProjectResourceEN>, IProjectResource
{
	public string Title { get; }	= CreateMember("Projects");
}

public record ProjectResourceNL : Resource<ProjectResourceNL>, IProjectResource
{
	public string Title { get; }	= CreateMember("Projecten");
}