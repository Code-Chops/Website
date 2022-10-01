using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

		var host = builder.Build();

		var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
		var defaultLanguageCode = await jsRuntime.InvokeAsync<string>("blazorCulture.get");
		LanguageSelector.SetNewCulture(defaultLanguageCode);

		var value = await jsRuntime.InvokeAsync<string>("blazorColorMode.get");
		var colorMode = value == nameof(ColorMode.DarkMode)
			? ColorMode.DarkMode
			: ColorMode.LightMode;

		ColorModeSelector.SetMode(colorMode);

		ConfigureSharedServices(builder.Services, defaultLanguageCode);

		await host.RunAsync();
	}

	public static void ConfigureSharedServices(IServiceCollection services, string? defaultLanguageCode = null)
	{
		var culture = defaultLanguageCode ?? LanguageSelector.SupportedLanguages.First();

		services.Configure<RequestLocalizationOptions>(options =>
		{
			options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture);
			options.SupportedUICultures = LanguageSelector.SupportedLanguages.Select(language => new CultureInfo(language)).ToList();
		});
	}
}