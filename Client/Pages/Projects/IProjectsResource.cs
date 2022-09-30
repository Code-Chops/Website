using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Projects;

[DiscoverImplementations]
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
	public string MagicEnums_Text { get; }		= CreateMember(@"
Better enums in C# <br/>
Flexible, extendable, and customizable
");
	public string MagicEnums_Title { get; }		= CreateMember("MagicEnums");
	public string VendingMachine_Text { get; }	= CreateMember(@"
Demo of a solution to<br/>
the vending machine change problem
");
	public string VendingMachine_Title { get; } = CreateMember("FoodChops");
	public string Title { get; }				= CreateMember("Projects");
}

public record ProjectsResourceNL : MagicStringEnum<ProjectsResourceNL>, IProjectsResource
{
	public string MagicEnums_Text { get; }		= CreateMember(@"
Betere enums in C# <br/>
Flexibel, uitbreidbaar en aanpasbaar
");
	public string MagicEnums_Title { get; }		= CreateMember("MagicEnums");
	public string VendingMachine_Text { get; }	= CreateMember(@"
Demo van een oplossing voor<br/>
het wisselgeldprobleem
");
	public string VendingMachine_Title { get; } = CreateMember("FoodChops");
	public string Title { get; }				= CreateMember("Projecten");
}