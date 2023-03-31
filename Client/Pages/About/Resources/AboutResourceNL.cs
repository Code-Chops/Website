// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.About.Resources;

public record AboutResourceNL : Resource<AboutResourceNL, ResourceProxyEnum>, IAboutResource
{
	public static string ChamberOfCommerce { get; }	= CreateMember(@"
KvK-nummer: 86790390 - btw-nummer: NL004317143B09
");

	public static string Paragraph1 { get; }		= CreateMember(@"
Ik ben Max Bergman, een full-stack senior software ontwikkelaar. 
Op deze plek deel ik updates van mijn laatste projecten en plaats ik tips voor andere ontwikkelaars.
Omdat mijn streven om de nieuwste technieken te gebruiken een voortdurend proces is, zal ik hier regelmatig updates geven van mijn laatste ervaringen in software-ontwikkeling.
");

	public static string Paragraph2 { get; }		= CreateMember(@"
Mijn carrière in software-ontwikkeling focust zich voornamelijk rondom het .NET ecosysteem.
Ik gebruik voornamelijk C#, .NET, Blazor, HTML, CSS, TypeScript, JavaScript, en MySQL / PostgreSQL.
");

	public static string Paragraph3 { get; }		= CreateMember(@"
Voel je vrij om contact op te nemen voor opdrachten, vragen of opmerkingen. Dit wordt erg gewaardeerd!
");

	public static string Title { get; }				= CreateMember(@"
Over
");
}
