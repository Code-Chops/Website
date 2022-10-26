
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Projects;

public record ProjectResource : Resource<ProjectResource, ResourceProxyEnum>
{
	public static string Title => CreateMember("Projects");
}

public record ProjectResourceNL : Resource<ProjectResourceNL, ResourceProxyEnum>
{
	public static string Title { get; }	= CreateMember("Projecten");
}

public interface IProjectOverviewResource
{
	public static abstract string Baxo { get; }
	public static abstract string Contracts { get; }
	public static abstract string Crossfade { get; }
	public static abstract string DomainModeling { get; }
	public static abstract string GenericMath { get; }
	public static abstract string Geometry { get; }
	public static abstract string ImplementationDiscovery { get; }
	public static abstract string Junctions { get; }
	public static abstract string MagicEnums { get; }
	public static abstract string VendingMachine { get; }
}

public record ProjectOverviewTitleResource : Resource<ProjectOverviewTitleResource, ResourceProxyEnum>, IProjectOverviewResource
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

public record ProjectOverviewTextResource : Resource<ProjectOverviewTextResource, ResourceProxyEnum>, IProjectOverviewResource
{

	public static string Baxo						=> CreateMember(@"
Baxo
");

	public static string Contracts					=> CreateMember(@"
Easy use of contracts,<br/>
adapters and polymorphism
");
	
	public static string Crossfade					=> CreateMember(@"
Blazor component for<br/> 
crossfades between webpages
");
	
	public static string DomainModeling				=> CreateMember(@"
Domain modeling using Domain<br/>
Driven Design principles
");
	
	public static string GenericMath				=> CreateMember(@"
Perform numerical computations<br/>
on generic types
");
	
	public static string Geometry					=> CreateMember(@"
Helper for calculation of objects</br>
in 2D space and time
");
	
	public static string ImplementationDiscovery	=> CreateMember(@"
Discover object implementations<br/>
at design time
");
	
	public static string Junctions					=> CreateMember(@"
Multiplayer word game<br/>
where creativity is awarded
");
	
	public static string MagicEnums					=> CreateMember(@"
Better enums in C#<br/>
Flexible, extendable, and customizable
");
	
	public static string VendingMachine				=> CreateMember(@"
Demo of a solution to<br/>
the vending machine change problem
");
}

public record ProjectOverviewTextResourceNL : Resource<ProjectOverviewTextResourceNL, ResourceProxyEnum>, IProjectOverviewResource
{
	public static string Baxo { get; }						= CreateMember(@"
Baxo
");
	
	public static string Contracts { get; }					= CreateMember(@"
Eenvoudig gebruik van contracten,<br/>
adapters en polymorfisme");
	
	public static string Crossfade { get; }					= CreateMember(@"
Blazor component voor een<br/> 
crossfade tussen webpagina's");
	
	public static string DomainModeling { get; }			= CreateMember(@"
Domeinmodellering volgens de<br/>
principes van Domain Driven Design
");
	
	public static string GenericMath { get; }				= CreateMember(@"
Voer numerieke berekeningen uit<br/>
op generieke types
");
	
	public static string Geometry { get; }					= CreateMember(@"
Helper voor berekening van objecten<br/>
in 2D ruimte en tijd
");	

	public static string ImplementationDiscovery { get; }	= CreateMember(@"
Ontdek objectimplementaties<br/>
terwijl je programmeert
");
	
	public static string Junctions { get; }					= CreateMember(@"
Woordspel voor meerdere spelers<br/>
waar creativiteit wordt beloond
");

	public static string MagicEnums { get; }				= CreateMember(@"
Betere enums in C# <br/>
Flexibel, uitbreidbaar en aanpasbaar
");
	
	public static string VendingMachine { get; }			= CreateMember(@"
Demo van een oplossing voor<br/>
het wisselgeldprobleem
");
}
