using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Pages.About;

[DiscoverImplementations(hasNewableImplementations: true)]
public partial interface IAboutResource : IResource<IAboutResource, IAboutResourceEnum>
{
	string ChamberOfCommerce { get; }
	string Paragraph1 { get; }
	string Paragraph2 { get; }
	string Paragraph3 { get; }
	string Title { get; }
}

public record AboutResourceEN : MagicStringEnum<AboutResourceEN>, IAboutResource
{
	public string ChamberOfCommerce { get; } = GetOrCreateMember<AboutResourceEN>(@"COC number: 86790390 - VAT number: NL004317143B09").Value;
	
	public string Paragraph1 { get; } = CreateMember(@"
I am Max Bergman, a full-stack senior software engineer.
This is a place where I share updates of my latest projects and post tips for other developers. 
I will also share my recent experiences in software development, as my endeavour to use the newest techniques is never-ending.
").Value;

	public string Paragraph2 { get; } = CreateMember(@"
My development career focuses mainly on the .NET ecosystem.
Currently, I am mainly using: C#, .NET, Blazor, HTML, TypeScript, JavaScript, and MySQL.
").Value;

	public string Paragraph3 { get; } = CreateMember(@"
Feel free to contact me if you have any questions, remarks or comments. It'll be greatly appreciated!
").Value;

	public string Title { get; } = CreateMember(@"About").Value;
}

public record AboutResourceNL : MagicStringEnum<AboutResourceNL>, IAboutResource
{
	public string ChamberOfCommerce { get; } = CreateMember(@"KvK-nummer: 86790390 - btw-nummer: NL004317143B09").Value;
	
	public string Paragraph1 { get; } = CreateMember(@"
Ik ben Max Bergman, een full-stack senior software ontwikkelaar. 
Op deze plek deel ik updates van mijn laatste projecten en plaats ik tips voor andere ontwikkelaars.
Omdat mijn streven om de nieuwste technieken te gebruiken een voortdurend proces is, zal ik hier regelmatig updates geven van mijn laatste ervaringen in software-ontwikkeling.
").Value;

	public string Paragraph2 { get; } = CreateMember(@"
Mijn carrière in software-ontwikkeling focust zich hoofdzakelijk rondom het .NET ecosysteem.
Momenteel gebruik ik voornamelijk: C#, .NET, Blazor, HTML, TypeScript, JavaScript, and MySQL.
").Value;

	public string Paragraph3 { get; } = CreateMember(@"
Voel je vrij om contact met me op te nemen bij vragen of opmerkingen. Dit wordt erg gewaardeerd!
").Value;

	public string Title { get; } = CreateMember(@"Over").Value;
}