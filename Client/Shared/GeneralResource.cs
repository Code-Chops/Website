// ReSharper disable InconsistentNaming

namespace CodeChops.Website.Client.Shared;

public record GeneralResource : Resource<GeneralResource, ResourceProxyEnum>
{
	public static string PageNotFound		=> CreateMember("""
	                                 		                Sorry, this page does not exist.
	                                 		                """);
	public static string BackToHome			=> CreateMember("""
	                               			                Go to the home page
	                               			                """);
	public static string Error				=> CreateMember("""
				                                            An unhandled error has occurred. Please send an angry e-mail to
				                                            <a href="mailto: hello@codechops.nl">hello@codechops.nl</a>
				                                            or
				                                            <a href="" class="reload">reload</a>
				                                            the page.
				                                            """);
	public static string NotAuthorized		=> CreateMember("""
	                                  		                Access denied.
	                                  		                """);
	public static string DocumentationLink	=> CreateMember("""
	                                      	                This text originates from
	                                      	                """);
	public static string OnlyInEnglish		=> CreateMember("");
	public static string GitHub				=> CreateMember("""
	                           				                GitHub
	                           				                """);
	public static string LinkedIn			=> CreateMember("""
	                             			                LinkedIn
	                             			                """);
}
