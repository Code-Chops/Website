using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Projects;

[DiscoverImplementations]
public partial interface IProjectsResource : IResource<IProjectsResource, IProjectsResourceEnum>
{
	string Crossfade_Text { get; }
	string Crossfade_Title { get; }
	string ImplementationDiscovery_Text { get; }
	string ImplementationDiscovery_Title { get; }
	string MagicEnums_Text { get; }
	string MagicEnums_Title { get; }
	string VendingMachine_Text { get; }
	string VendingMachine_Title { get; }
	string Title { get; }
}

public record ProjectsResourceEN : MagicStringEnum<ProjectsResourceEN>, IProjectsResource
{
	public string Crossfade_Text { get; }					= CreateMember(@"
Blazor component for<br/> 
crossfades between webpages
");
	public string Crossfade_Title { get; }					= CreateMember("Crossfade");
	public string ImplementationDiscovery_Text { get; }		= CreateMember(@"
Discover object implementations<br/>
at design time
");
	public string ImplementationDiscovery_Title { get; }	= CreateMember("Implementation discovery");
	public string MagicEnums_Text { get; }					= CreateMember(@"
Better enums in C#<br/>
Flexible, extendable, and customizable
");
	public string MagicEnums_Title { get; }					= CreateMember("MagicEnums");
	public string VendingMachine_Text { get; }				= CreateMember(@"
Demo of a solution to<br/>
the vending machine change problem
");
	public string VendingMachine_Title { get; }				= CreateMember("FoodChops");
	public string Title { get; }							= CreateMember("Projects");
}

public record ProjectsResourceNL : MagicStringEnum<ProjectsResourceNL>, IProjectsResource
{
	public string Crossfade_Text { get; }					= CreateMember(@"
Blazor component voor een<br/> 
crossfade tussen webpagina's");
	public string Crossfade_Title { get; }					= CreateMember("Crossfade");
	public string ImplementationDiscovery_Text { get; }		= CreateMember(@"
Ontdek object-implementaties<br/>
, using source generators
");
	public string ImplementationDiscovery_Title { get; }	= CreateMember("Implementation discovery");
	public string MagicEnums_Text { get; }					= CreateMember(@"
Betere enums in C# <br/>
Flexibel, uitbreidbaar en aanpasbaar
");
	public string MagicEnums_Title { get; }					= CreateMember("MagicEnums");
	public string VendingMachine_Text { get; }				= CreateMember(@"
Demo van een oplossing voor<br/>
het wisselgeldprobleem
");
	public string VendingMachine_Title { get; }				= CreateMember("FoodChops");
	public string Title { get; }							= CreateMember("Projecten");
}