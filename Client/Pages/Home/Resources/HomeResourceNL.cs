namespace CodeChops.Website.Client.Pages.Home.Resources;

public record HomeResourceNL : Resource<HomeResourceNL, ResourceProxyEnum>
{
	public static string Title { get; }			= CreateMember("""
			                                                   Welkom
			                                                   """);

	public static string Author { get; }		= CreateMember("""
			                                                   Website, logo, design en animaties door CodeChops
			                                                   """);

	public static string Paragraph1 { get; }	= CreateMember("""
		                                                       CodeChops focust zich op het maken van high-end software die precies op jouw wensen aansluit.
		                                                       Tijdens het ontwikkelproces wordt er zorgvuldig rekening gehouden met de unieke situatie van jouw bedrijf.
		                                                       """);

	public static string Paragraph2 { get; }	= CreateMember("""
		                                                       De huidige portfolio varieert van front-end tot back-end (zie <a href="projects">projecten</a>).
		                                                       CodeChops levert hierbij graag full-stack oplossingen om zo een naadloze geïntegreerde ervaring te bieden.
		                                                       """);
}
