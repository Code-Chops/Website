// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client;

public record GeneralResource : Resource<GeneralResource, ResourceProxyEnum>
{
	public static string PageNotFound		=> CreateMember("Sorry, this page does not exist.");
	
	public static string Error				=> CreateMember(@"
An unhandled error has occurred. Please send an angry e-mail to 
<a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
or 
<a href="""" class=""reload"">reload</a>
the page.
");
	
	public static string NotAuthorized		=> CreateMember("Access denied.");
	
	public static string DocumentationLink	=> CreateMember("This text is synchronized with");
	public static string OnlyInEnglish		=> CreateMember(".");
	
	public static string GitHub				=> CreateMember("GitHub");
	public static string LinkedIn			=> CreateMember("LinkedIn");
}

public record GeneralResourceNL : Resource<GeneralResourceNL, ResourceProxyEnum>
{
	public static string PageNotFound { get; }		= CreateMember("Sorry, deze pagina bestaat niet.");
	
	public static string Error { get; }				= CreateMember(@"
Er is een fout opgetreden. Stuur een boze e-mail naar 
<a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
of 
<a href="""" class=""reload"">ververs</a>
de pagina.
");

	public static string NotAuthorized { get; }		= CreateMember("Toegang geweigerd.");

	public static string DocumentationLink { get; }	= CreateMember("Deze tekst is gesynchroniseerd met");
	public static string OnlyInEnglish { get; }		= CreateMember("<br/>en is daarom alleen in het Engels beschikbaar.");
}
