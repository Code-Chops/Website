using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.Projects.Resources;

[DiscoverImplementations(hasNewableImplementations: true)]
public partial interface IProjectsResource : IResource<IProjectsResource, IProjectsResourceEnum>
{
	string MagicEnums_Text { get; }
	string MagicEnums_Title { get; }
	string VendingMachine_Text { get; }
	string VendingMachine_Title { get; }
	string Title { get; }
}

public record ProjectsResourceEN : MagicStringEnum<ProjectsResourceEN>, IProjectsResource
{
	public string MagicEnums_Text { get; } = CreateMember(@"
Better enums in C# <br/>
Flexible, extendable, and customizable
").Value;
	public string MagicEnums_Title { get; } = CreateMember("MagicEnums").Value;
	public string VendingMachine_Text { get; } = CreateMember(@"
Demo of a solution to<br/>
the vending machine change problem
").Value;
	public string VendingMachine_Title { get; } = CreateMember("FoodChops").Value;
	public string Title { get; } = CreateMember("Projects").Value;
}

public record ProjectsResourceNL : MagicStringEnum<ProjectsResourceNL>, IProjectsResource
{
	public string MagicEnums_Text { get; } = CreateMember(@"
Betere enums in C# <br/>
Flexibel, uitbreidbaar en aanpasbaar
").Value;
	public string MagicEnums_Title { get; } = CreateMember("MagicEnums").Value;
	public string VendingMachine_Text { get; } = CreateMember(@"
Demo van een oplossing voor<br/>
het wisselgeldprobleem
").Value;
	public string VendingMachine_Title { get; } = CreateMember("FoodChops").Value;
	public string Title { get; } = CreateMember("Projecten").Value;
}