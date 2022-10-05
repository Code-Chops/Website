using CodeChops.ImplementationDiscovery;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Projects;

public interface IProjectsResource
{
	string Baxo { get; }
	string Contracts { get; }
	string Crossfade { get; }
	string DomainModeling { get; }
	string GenericMath { get; }
	string Geometry { get; }
	string ImplementationDiscovery { get; }
	string Junctions { get; }
	string MagicEnums { get; }
	string VendingMachine { get; }
}

[DiscoverImplementations]
public partial interface IProjectsTitleResource : IResourceManager<IProjectsTitleResource, IProjectsTitleResourceEnum>, IProjectsResource
{
	string Baxo { get; }
	string Contracts { get; }
	string Crossfade { get; }
	string DomainModeling { get; }
	string GenericMath { get; }
	string Geometry { get; }
	string ImplementationDiscovery { get; }
	string Junctions { get; }
	string MagicEnums { get; }
	string VendingMachine { get; }
}

public record ProjectsTitleResource : Resource<ProjectsTitleResource>
{
	public static string Baxo { get; }						= CreateMember("Baxo");
	public static string Contracts { get; }					= CreateMember("DDD Contracts");
	public static string Crossfade { get; }					= CreateMember("Crossfade");
	public static string DomainModeling { get; }			= CreateMember("DDD Domain modeling");
	public static string GenericMath { get; }				= CreateMember("GenericMath");
	public static string Geometry { get; }					= CreateMember("Geometry");
	public static string ImplementationDiscovery { get; }	= CreateMember("Implementation discovery");
	public static string Junctions { get; }					= CreateMember("Junctions");
	public static string MagicEnums { get; }				= CreateMember("MagicEnums");
	public static string VendingMachine { get; }			= CreateMember("FoodChops");
}

[DiscoverImplementations]
public partial interface IProjectsTextResource : IResourceManager<IProjectsTextResource, IProjectsTextResourceEnum>, IProjectsResource
{
}

public record ProjectsTextResourceEN : Resource<ProjectsTextResourceEN>, IProjectsResource
{
	public string Baxo { get; }						= CreateMember(@"
Baxo
");

	public string Contracts { get; }				= CreateMember(@"
Easy use of contracts,<br/>
adapters and polymorphism
");
	
	public string Crossfade { get; }				= CreateMember(@"
Blazor component for<br/> 
crossfades between webpages
");
	
	public string DomainModeling { get; }			= CreateMember(@"
Domain modeling using Domain<br/>
Driven Design principles
");
	
	public string GenericMath { get; }				= CreateMember(@"
Perform numerical computations<br/>
on generic types
");
	
	public string Geometry { get; }					= CreateMember(@"
Helper for calculation of objects</br>
in 2D space and time
");
	
	public string ImplementationDiscovery { get; }	= CreateMember(@"
Discover object implementations<br/>
at design time
");
	
	public string Junctions { get; }				= CreateMember(@"
Multiplayer word game<br/>
where creativity is awarded
");
	
	public string MagicEnums { get; }				= CreateMember(@"
Better enums in C#<br/>
Flexible, extendable, and customizable
");
	
	public string VendingMachine { get; }			= CreateMember(@"
Demo of a solution to<br/>
the vending machine change problem
");
}

public record ProjectsTextResourceNL :  Resource<ProjectsTextResourceNL>, IProjectsResource
{
	public string Baxo { get; }				= CreateMember(@"
Baxo
");
	
	public string Contracts { get; }				= CreateMember(@"
Eenvoudig gebruik van contracten,<br/>
adapters en polymorfisme");
	
	public string Crossfade { get; }				= CreateMember(@"
Blazor component voor een<br/> 
crossfade tussen webpagina's");
	
	public string DomainModeling { get; }			= CreateMember(@"
Domeinmodellering volgens de<br/>
principes van Domain Driven Design
");
	
	public string GenericMath { get; }				= CreateMember(@"
Voer numerieke berekeningen uit<br/>
op generieke types
");
	
	public string Geometry { get; }					= CreateMember(@"
Helper voor berekening van objecten<br/>
in 2D ruimte en tijd
");	

	public string ImplementationDiscovery { get; }	= CreateMember(@"
Ontdek objectimplementaties<br/>
terwijl je programmeert
");
	
	public string Junctions { get; }				= CreateMember(@"
Woordspel voor meerdere spelers<br/>
waar creativiteit wordt beloond
");

	public string MagicEnums { get; }				= CreateMember(@"
Betere enums in C# <br/>
Flexibel, uitbreidbaar en aanpasbaar
");
	
	public string VendingMachine { get; }			= CreateMember(@"
Demo van een oplossing voor<br/>
het wisselgeldprobleem
");
}