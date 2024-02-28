namespace CodeChops.Website.Client.Pages.Projects.Resources;

public record ProjectOverviewTitleResource : Resource<ProjectOverviewTitleResource, ResourceProxyEnum>, IProjectOverviewResource
{
	// public static string Baxo { get; }						= CreateMember("""Baxo""");
	public static string Contracts { get; }					= CreateMember("""
	                                       					               Contracts (DDD)
	                                       					               """);
	public static string Crossblade { get; }				= CreateMember("""
	                                        				               Crossblade
	                                        				               """);
	public static string DomainModeling { get; }			= CreateMember("""
	                                            			               Domain modeling (DDD)
	                                            			               """);
	public static string GenericMath { get; }				= CreateMember("""
	                                         				               Generic math
	                                         				               """);
	public static string Geometry { get; }					= CreateMember("""
	                                      					               Geometry
	                                      					               """);
	public static string ImplementationDiscovery { get; }	= CreateMember("""
	                                                     	               Implementation discovery
	                                                     	               """);

	public static string Junctions { get; }					= CreateMember("""
	                                       					               Junctions
	                                       					               """);
	public static string MagicEnums { get; }				= CreateMember("""
	                                        				               Magic enums
	                                        				               """);
	public static string FoodChops { get; }					= CreateMember("""
	                                       					               FoodChops
	                                       					               """);
	public static string SourceGenerationUtilities { get; }	= CreateMember("""
	                                                       	               Source generation utilities
	                                                       	               """);
	public static string LightResources { get; }			= CreateMember("""
	                                            			               Light resources
	                                            			               """);

	public static string Blame { get; }						= CreateMember("""
	                                   						               Blame
	                                   						               """);
}
