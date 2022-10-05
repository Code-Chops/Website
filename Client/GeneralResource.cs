using CodeChops.ImplementationDiscovery;
using CodeChops.Website.Client.Resources;

namespace CodeChops.Website.Client;

[DiscoverImplementations]
public partial interface IGeneralResource : IResourceManager<IGeneralResource, IGeneralResourceEnum>
{
	string PageNotFound { get; }
	string Error { get; }
}

public record GeneralResourceEN : Resource<GeneralResourceEN>, IGeneralResource
{
	public string PageNotFound { get; } = CreateMember(@"
Sorry, this page doest not exist.
");
	
	public string Error { get; }		= CreateMember(@"
An unhandled error has occurred. Please send an angry e-mail to 
            <a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
            or 
            <a href="""" class=""reload"">reload</a>
            the page.
");
}

public record GeneralResourceNL : Resource<GeneralResourceNL>, IGeneralResource
{
	public string PageNotFound { get; } = CreateMember(@"
Sorry, deze pagina bestaat niet.
");
	
	public string Error { get; }		= CreateMember(@"
Er is een fout opgetreden. Stuur een boze e-mail naar 
            <a href=""mailto: hello@codechops.nl"">hello@codechops.nl</a>
            of 
            <a href="""" class=""reload"">ververs</a>
            de pagina.
");
}