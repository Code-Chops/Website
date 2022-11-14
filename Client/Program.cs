using System.Collections.Immutable;
using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CodeChops.Website.Client"));

builder.Services.AddCrossfade(inServerContext: false);

var host = builder.Build();

var jsRuntime = (IJSInProcessRuntime)host.Services.GetRequiredService<IJSRuntime>();

var supportedCountryCodes = new SupportedCountryCodes(new CountryCode[] { new("GB"), new("NL") }.ToImmutableList());
var defaultCountryCode = supportedCountryCodes[0];
builder.Services.AddCountryCache(supportedCountryCodes, defaultCountryCode);

var currentCountryCode = GetCurrentCountryCode(jsRuntime, supportedCountryCodes, defaultCountryCode);

CountryCodeCache.SetCurrentCountryCode(currentCountryCode);

var currentColorMode = GetCurrentColorMode(jsRuntime);

ColorModeSelector.SetMode(currentColorMode);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(currentCountryCode);
	options.SupportedUICultures = supportedCountryCodes.Select(country => new CultureInfo(country)).ToList();
});

await host.RunAsync();


static CountryCode GetCurrentCountryCode(IJSInProcessRuntime jsRuntime, SupportedCountryCodes supportedCountryCodes, CountryCode defaultCountryCode)
{
	var countryCode = jsRuntime.Invoke<string>("blazorCulture.get");

	return CountryCode.TryCreate(countryCode, out var currentCountryCode) && supportedCountryCodes.Value.Contains(currentCountryCode) 
		? currentCountryCode 
		: defaultCountryCode;
}

static ColorMode GetCurrentColorMode(IJSInProcessRuntime jsRuntime)
{
	var colorMode = jsRuntime.Invoke<string>("blazorColorMode.get");
	
	return ColorMode.TryGetSingleMember(colorMode, out var currentColorMode) 
		? currentColorMode 
		: ColorMode.LightMode;
}
