using CodeChops.Website.Client.Layout;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CodeChops.Crossblade;
using CodeChops.Website.Client.Pages.Authentication.AuthenticationStateSyncer;
using Microsoft.AspNetCore.Components.Authorization;
using RenderEnvironment = CodeChops.Crossblade.RenderEnvironment;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var services = builder.Services;
services.AddHttpClient();
services.AddCrossblade(new RenderEnvironment.WebassemblyClient());
services.AddSingleton<CodeChops.Website.RazorComponents.RenderEnvironment>(new CodeChops.Website.RazorComponents.RenderEnvironment.WebassemblyClient());

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

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
		currentLanguageCode = SupportedLanguageCodes.GetMembers().First().Value;

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
