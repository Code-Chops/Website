namespace CodeChops.Website.Client.Pages.Projects.Resources;

public record ProjectOverviewTextResource : Resource<ProjectOverviewTextResource, ResourceProxyEnum>, IProjectOverviewResource
{
	public static string Baxo						=> CreateMember("""
						                                            Baxo
						                                            """);

	public static string Contracts					=> CreateMember("""
					                                                Easy use of contracts,<br/>
					                                                adapters and polymorphism
					                                                """);

	public static string Crossblade					=> CreateMember("""
					                                                Blazor component for<br/>
					                                                crossfades between webpages
					                                                """);

	public static string DomainModeling				=> CreateMember("""
				                                                    Domain modeling using<br/>
				                                                    Domain Driven Design principles
				                                                    """);

	public static string GenericMath				=> CreateMember("""
					                                                Perform numerical computations<br/>
					                                                on generic types
					                                                """);

	public static string Geometry					=> CreateMember("""
					                                                Helper for calculation of objects<br/>
					                                                in 2D space and time
					                                                """);

	public static string ImplementationDiscovery	=> CreateMember("""

		                                                            Discover object implementations<br/>
		                                                            at design time

		                                                            """);

	public static string Junctions					=> CreateMember("""
					                                                Multiplayer word game<br/>
					                                                where creativity is rewarded
					                                                """);

	public static string MagicEnums					=> CreateMember("""
					                                                Better enums in C#<br/>
					                                                Flexible, extendable, and customizable
					                                                """);

	public static string FoodChops					=> CreateMember("""
					                                                Demo of a solution to<br/>
					                                                the vending machine change problem
					                                                """);

	public static string SourceGenerationUtilities	=> CreateMember("""
	                                                                Utilities to simplify<br/>
	                                                                source generators implementation
	                                                                """);

	public static string LightResources				=> CreateMember("""
				                                                    Dynamic, light resources<br/>
				                                                    for website globalization
				                                                    """);

	public static string Blame						=> CreateMember("""
						                                            Light 2D game engine<br/>
						                                            for Blazor
						                                            """);
}
