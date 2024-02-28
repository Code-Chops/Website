namespace CodeChops.Website.Client.Shared;

public record GeneralResourceNL : Resource<GeneralResourceNL, ResourceProxyEnum>
{
	public static string PageNotFound { get; }		= CreateMember("""
	                                          		               Sorry, deze pagina bestaat niet.
	                                          		               """);

	public static string BackToHome			 		= CreateMember("""
	                               			 		               Ga naar de homepagina
	                               			 		               """);

	public static string Error { get; }				= CreateMember("""
				                                                   Er is een fout opgetreden. Stuur een boze e-mail naar
				                                                   <a href="mailto: hello@codechops.nl">hello@codechops.nl</a>
				                                                   of
				                                                   <a href="" class="reload">ververs</a>
				                                                   de pagina.
				                                                   """);

	public static string NotAuthorized { get; }		= CreateMember("""
	                                           		               Toegang geweigerd.
	                                           		               """);

	public static string DocumentationLink { get; }	= CreateMember("""
	                                               	               Deze tekst is afkomstig van
	                                               	               """);

	public static string OnlyInEnglish { get; }		= CreateMember("""
	                                           		               en is daarom alleen in het Engels beschikbaar
	                                           		               """);
}
