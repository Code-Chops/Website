using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client.Pages.Home;

[DiscoverImplementations]
public partial interface IHomeResource : IResource<IHomeResource, IHomeResourceEnum>
{
	string Author		{ get; }
	string FullTitle	{ get; }
	string Paragraph1	{ get; }
	string Paragraph2	{ get; }
	string Title		{ get; }
}

public record HomeResourceEN : MagicStringEnum<HomeResourceEN>, IHomeResource
{
	public string FullTitle { get; }	= CreateMember("Welcome to CodeChops");
	public string Author { get; }		= CreateMember("Logo, design and website by CodeChops");
	public string Paragraph1 { get; }	= CreateMember(@"
CodeChops delivers top-notch software tailor-made to meet your specific needs. 
Solutions are built through careful consideration of your company's unique situation during the development process
");
	public string Paragraph2 { get; }	= CreateMember(@"
The current portfolio varies from front-end to back-end (see <a href=""projects"">projects</a>). 
CodeChops preferably delivers full-stack solutions in order to provide a seamless integrated experience.
	");
	public string Title { get; }		= CreateMember("Welcome");
}

public record HomeResourceNL : MagicStringEnum<HomeResourceNL>, IHomeResource
{
	public string FullTitle { get; }	= CreateMember("Welkom bij CodeChops");
	public string Author { get; }		= CreateMember("Logo, design en website door CodeChops");
	public string Paragraph1 { get; }	= CreateMember(@"
CodeChops focust zich op het maken van high-end software die precies op jouw wensen aansluit.
Tijdens het ontwikkelproces wordt er zorgvuldig rekening gehouden met de unieke situatie van jouw bedrijf.
");
	public string Paragraph2 { get; }	= CreateMember(@"
De huidige portfolio varieert van front-end tot back-end (zie <a href=""projects"">projecten</a>).
CodeChops levert hierbij graag full-stack oplossingen om zo een naadloze geïntegreerde ervaring te bieden.
");
	public string Title { get; }		= CreateMember("Welkom");
}