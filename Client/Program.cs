using CodeChops.Website.Client.Layout;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using CodeChops.Crossblade;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient();
builder.Services.AddCrossblade(new RenderEnvironment.WebassemblyClient());
builder.Services.AddSingleton<CodeChops.Website.RazorComponents.RenderEnvironment>(new CodeChops.Website.RazorComponents.RenderEnvironment.WebassemblyClient());

builder.RootComponents.Add<HeadOutlet>("head::after");

var host = builder.Build();

var jsRuntime = (IJSInProcessRuntime)host.Services.GetRequiredService<IJSRuntime>();

builder.Services.AddLightResources(new LanguageCode[] { new("en-GB"), new("nl-NL") });

var currentColorMode = GetCurrentColorMode(jsRuntime);
ColorModeSelector.SetMode(currentColorMode);

var currentLanguageCode = GetCurrentLanguageCode(jsRuntime);
LanguageCodeCache.SetCurrentLanguage(currentLanguageCode);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(currentLanguageCode);
	options.SupportedUICultures = SupportedLanguageCodes.GetValues().Select(languageCode => new CultureInfo(languageCode)).ToList();
});

await host.RunAsync();


static LanguageCode GetCurrentLanguageCode(IJSInProcessRuntime jsRuntime)
{
	var languageCode = jsRuntime.Invoke<string>("blazorCulture.get");

	if (!LanguageCode.TryCreate(languageCode, out var currentLanguageCode))
		currentLanguageCode = SupportedLanguageCodes.GetMembers().First();
	
	return SupportedLanguageCodes.TryGetMembers(currentLanguageCode, out _) 
		? currentLanguageCode 
		: SupportedLanguageCodes.GetMembers().First().Value;
}

static ColorMode GetCurrentColorMode(IJSInProcessRuntime jsRuntime)
{
	var colorMode = jsRuntime.Invoke<string>("blazorColorMode.get");
	
	return ColorMode.TryGetSingleMember(colorMode, out var currentColorMode) 
		? currentColorMode 
		: ColorMode.LightMode;
}
