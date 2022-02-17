using System.Globalization;
using CodeChops.Website.Client.Layout;
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
		builder.Services.AddHttpContextAccessor();

		var host = builder.Build();

		var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
		var defaultCulture = await jsRuntime.InvokeAsync<string>("blazorCulture.get");
		LanguageSelector.SetNewCulture(defaultCulture);

		var value = await jsRuntime.InvokeAsync<string>("blazorColorMode.get");
		ColorMode colorMode = value == nameof(DarkMode)
			? DarkMode.Instance
			: LightMode.Instance;

		ColorModeSelector.SetMode(colorMode);

		ConfigureSharedServices(builder.Services, defaultCulture);

		await host.RunAsync();
	}

	public static void ConfigureSharedServices(IServiceCollection services, string? defaultCulture = null)
	{
		services.AddLocalization();

		var supportedCultures = LanguageSelector.SupportedLanguages.Select(language => new CultureInfo(language)).ToList();
		defaultCulture ??= supportedCultures.First().TwoLetterISOLanguageName;

		services.Configure<RequestLocalizationOptions>(options =>
		{
			options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
			options.SupportedUICultures = supportedCultures;
		});
	}
}