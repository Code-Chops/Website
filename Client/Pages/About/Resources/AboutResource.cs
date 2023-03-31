namespace CodeChops.Website.Client.Pages.About.Resources;

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
