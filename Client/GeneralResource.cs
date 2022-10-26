// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client;

public record GeneralResource : Resource<GeneralResource, ResourceProxyEnum>
{
	public static string PageNotFound	=> CreateMember(@"
Sorry, this page doest not exist.
");
	
	public static string Error			=> CreateMember(@"
An unhandled error has occurred. Please send an angry e-mail to 
            <a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
            or 
            <a href="""" class=""reload"">reload</a>
            the page.
");
}

public record GeneralResourceNL : Resource<GeneralResourceNL, ResourceProxyEnum>
{
	public static string PageNotFound { get; }	= CreateMember(@"
Sorry, deze pagina bestaat niet.
");
	
	public static string Error { get; }			= CreateMember(@"
Er is een fout opgetreden. Stuur een boze e-mail naar 
            <a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
            of 
            <a href="""" class=""reload"">ververs</a>
            de pagina.
");
}
