
// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Home;

public record HomeResource : Resource<HomeResource, ResourceProxyEnum>
{
	public static string FullTitle => CreateMember(@"
Welcome to CodeChops
");
	
	public static string Author => CreateMember(@"
Logo, design and website by CodeChops
");
	
	public static string Paragraph1 => CreateMember(@"
CodeChops delivers top-notch software tailor-made to meet your specific needs. 
Solutions are built through careful consideration of your company's unique situation during the development process
");
	
	public static string Paragraph2 => CreateMember(@"
The current portfolio varies from front-end to back-end (see <a href=""projects"">projects</a>). 
CodeChops preferably delivers full-stack solutions in order to provide a seamless integrated experience.
	");
	
	public static string Title => CreateMember(@"
Welcome
");
}

public record HomeResourceNL : Resource<HomeResourceNL, ResourceProxyEnum>
{
	public static string FullTitle { get; }		= CreateMember(@"
Welkom bij CodeChops
");
	
	public static string Author { get; }		= CreateMember(@"
Logo, design en website door CodeChops
");
	
	public static string Paragraph1 { get; }	= CreateMember(@"
CodeChops focust zich op het maken van high-end software die precies op jouw wensen aansluit.
Tijdens het ontwikkelproces wordt er zorgvuldig rekening gehouden met de unieke situatie van jouw bedrijf.
");
	
	public static string Paragraph2 { get; }	= CreateMember(@"
De huidige portfolio varieert van front-end tot back-end (zie <a href=""projects"">projecten</a>).
CodeChops levert hierbij graag full-stack oplossingen om zo een naadloze geïntegreerde ervaring te bieden.
");
	
	public static string Title { get; }			= CreateMember(@"
Welkom
");
}
