using System.Globalization;
using System.Net.Http;
using CodeChops.Website.Client.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace CodeChops.Website.Client;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<HeadOutlet>("head::after");

		//builder.Services.AddHttpClient("CodeChops.Website.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
		//	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

		// Supply HttpClient instances that include access tokens when making requests to the server project
		builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CodeChops.Website.ServerAPI"));
		builder.Services.AddSingleton<RenderLocation, RenderedOnClient>();

		//builder.Services.AddApiAuthorization();
		builder.Services.AddHttpContextAccessor();

		ConfigureSharedServices(builder.Services, out var defaultCulture);

		var host = builder.Build();

		var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
		var result = await jsRuntime.InvokeAsync<string>("blazorCulture.get");

		LanguageSelector.SetNewCulture("nl", jsRuntime);

		await host.RunAsync();
	}

	public static void ConfigureSharedServices(IServiceCollection services, out string defaultCulture)
	{
		// Common service registrations that both apps use
		//services.Add...;
		services.AddLocalization();
		var supportedCultures = LanguageSelector.SupportedLanguages.Select(language => new CultureInfo(language)).ToList();
		services.Configure<RequestLocalizationOptions>(options =>
		{
			options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures.First());
			options.SupportedUICultures = supportedCultures;
		});
		defaultCulture = supportedCultures.First().TwoLetterISOLanguageName;
	}
}