namespace CodeChops.Website.Client.Pages.Projects.Resources;

public record ProjectOverviewTextResourceNL : Resource<ProjectOverviewTextResourceNL, ResourceProxyEnum>, IProjectOverviewResource
{
	public static string Baxo { get; }						= CreateMember("""
						                                                   Baxo
						                                                   """);

	public static string Contracts { get; }					= CreateMember("""
					                                                       Eenvoudig gebruik van contracten,<br/>
					                                                       adapters en polymorfisme
					                                                       """);

	public static string Crossblade { get; }				= CreateMember("""
					                                                       Blazor component voor<br/>
					                                                       crossfades tussen webpagina's
					                                                       """);

	public static string DomainModeling { get; }			= CreateMember("""
				                                                           Domeinmodelvorming volgens de<br/>
				                                                           principes van Domain Driven Design
				                                                           """);

	public static string GenericMath { get; }				= CreateMember("""
				                                                           Voer numerieke berekeningen uit<br/>
				                                                           op generieke numerieke types
				                                                           """);

	public static string Geometry { get; }					= CreateMember("""
					                                                       Helper voor berekening van objecten<br/>
					                                                       in 2D ruimte en tijd
					                                                       """);

	public static string ImplementationDiscovery { get; }	= CreateMember("""
	                                                                       Ontdek objectimplementaties<br/>
	                                                                       terwijl je programmeert
	                                                                       """);

	public static string Junctions { get; }					= CreateMember("""
					                                                       Woordspel voor meerdere spelers<br/>
					                                                       waar creativiteit wordt beloond
					                                                       """);

	public static string MagicEnums { get; }				= CreateMember("""
					                                                       Betere enums in C#<br/>
					                                                       Flexibel, uitbreidbaar en aanpasbaar
					                                                       """);

	public static string FoodChops { get; }					= CreateMember("""
					                                                       Demo van een oplossing voor<br/>
					                                                       het wisselgeldprobleem
					                                                       """);

	public static string SourceGenerationUtilities { get; }	= CreateMember("""
	                                                                       Tools om codegenerators<br/>
	                                                                       makkelijker te implementeren
	                                                                       """);

	public static string LightResources { get; }			= CreateMember("""
				                                                           Lichte, dynamische resources<br/>
				                                                           voor websitelokalisatie
				                                                           """);

	public static string Blame { get; }						= CreateMember("""
						                                                   Lichte, 2D game engine<br/>
						                                                   voor Blazor
						                                                   """);
}
