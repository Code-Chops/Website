// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.About;

public interface IAboutResource
{
	public static abstract string ChamberOfCommerce { get; }
	public static abstract string Paragraph1 { get; }
	public static abstract string Paragraph2 { get; }
	public static abstract string Paragraph3 { get; }
	public static abstract string Title { get; }
}

public record AboutResource : Resource<AboutResource, ResourceProxyEnum>, IAboutResource
{
	public static string ChamberOfCommerce	=> CreateMember(@"
COC number: 86790390 - VAT number: NL004317143B09
");

	public static string Paragraph1			=> CreateMember(@"
I am Max Bergman, a full-stack senior software engineer.
This is a place where I share updates of my latest projects and post tips for other developers.
I will also share my recent experiences in software development, as my endeavour to use the newest techniques is never-ending.
");

	public static string Paragraph2			=> CreateMember(@"
My development career focuses mainly on the .NET ecosystem.
I am mainly using C#, .NET, Blazor, HTML, CSS, TypeScript, JavaScript, and MySQL / PostgreSQL.
");

	public static string Paragraph3			=> CreateMember(@"
Feel free to contact me for work, questions or comments. It'll be greatly appreciated!
");

	public static string Title				=> CreateMember(@"
About
");
}

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
Op dit moment ben ik alleen beschikbaar voor werk op afstand. Voel je vrij om contact op te nemen voor opdrachten, vragen of opmerkingen. Dit wordt erg gewaardeerd!
");

	public static string Title { get; }				= CreateMember(@"
Over
");
}
