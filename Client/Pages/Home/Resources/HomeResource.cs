// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Pages.Home.Resources;

public record HomeResource : Resource<HomeResource, ResourceProxyEnum>
{
	public static string Title		=> CreateMember(@"
Welcome
");

	public static string Author		=> CreateMember(@"
Website, logo, animations, and design by CodeChops
");
	
	public static string Paragraph1 => CreateMember(@"
CodeChops delivers top-notch software tailor-made to meet your specific needs.
Solutions are built through careful consideration of your company's unique situation during the development process.
");
	
	public static string Paragraph2	=> CreateMember(@"
The current portfolio varies from front-end to back-end (see <a href=""projects"">projects</a>).
CodeChops preferably delivers full-stack solutions in order to provide a seamless integrated experience.
");
}
