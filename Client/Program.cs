using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient();

builder.Services.AddCrossfade(inServerContext: false);

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<RenderLocation>(new RenderedOnClient());

var host = builder.Build();

var jsRuntime = (IJSInProcessRuntime)host.Services.GetRequiredService<IJSRuntime>();

builder.Services.AddLanguageCodeCache(new [] { "en-GB", "nl-NL" });

var currentColorMode = GetCurrentColorMode(jsRuntime);
ColorModeSelector.SetMode(currentColorMode);

var currentLanguageCode = GetCurrentLanguageCode(jsRuntime);

LanguageCodeCache.SetCurrentLanguageCode(currentLanguageCode);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(currentLanguageCode);
	options.SupportedUICultures = SupportedLanguageCodes.GetValues().Select(languageCode => new CultureInfo(languageCode)).ToList();
});

await host.RunAsync();


static LanguageCode GetCurrentLanguageCode(IJSInProcessRuntime jsRuntime)
{
	var languageCode = jsRuntime.Invoke<string>("blazorCulture.get");

	// LanguageCode.TryCreate(languageCode, out var currentLanguageCode) &&
	var currentLanguageCode = new LanguageCode(languageCode);
	return SupportedLanguageCodes.TryGetMembers(currentLanguageCode, out _) 
		? currentLanguageCode 
		: SupportedLanguageCodes.GetMembers().First();
}

static ColorMode GetCurrentColorMode(IJSInProcessRuntime jsRuntime)
{
	var colorMode = jsRuntime.Invoke<string>("blazorColorMode.get");
	
	return ColorMode.TryGetSingleMember(colorMode, out var currentColorMode) 
		? currentColorMode 
		: ColorMode.LightMode;
}
