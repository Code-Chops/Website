using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.Website.Client;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<HeadOutlet>("head::after");

		builder.Services.AddHttpClient("CodeChops.Website.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
			.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

		// Supply HttpClient instances that include access tokens when making requests to the server project
		builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CodeChops.Website.ServerAPI"));
		builder.Services.AddSingleton<RenderLocation, RenderedOnClient>();

		//builder.Services.AddApiAuthorization();
		builder.Services.AddHttpContextAccessor();

		await builder.Build().RunAsync();
	}

	public static void ConfigureSharedServices(IServiceCollection services)
	{
		// Common service registrations that both apps use
		//services.Add...;
	}
}