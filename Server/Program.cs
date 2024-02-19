using System.Globalization;
using CodeChops.Crossblade;
using CodeChops.LightResources;
using CodeChops.Website.Client;
using Auth0.AspNetCore.Authentication;
using CodeChops.Website.Server.AuthenticationStateSyncer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddCascadingAuthenticationState();
services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

services
	.AddAuth0WebAppAuthentication(options => {
		options.Domain = builder.Configuration["Auth0:Domain"]!;
		options.ClientId = builder.Configuration["Auth0:ClientId"]!;
	});

services.AddControllersWithViews();

services.AddRazorComponents()
	.AddInteractiveWebAssemblyComponents()
	.AddInteractiveServerComponents();

services.AddCrossblade(new RenderEnvironment.WebassemblyHost());
services.AddSingleton<CodeChops.Website.RazorComponents.RenderEnvironment>(new CodeChops.Website.RazorComponents.RenderEnvironment.WebassemblyHost());

services.AddLightResources(new LanguageCode[] { new("en-GB"), new("nl-NL") });

services.AddSingleton(builder.Environment);

services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(LanguageCodeCache.CurrentLanguageCode);
	options.SupportedUICultures = SupportedLanguageCodes.GetValues().Select(languageCode => new CultureInfo(languageCode)).ToList();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
	app.UseWebAssemblyDebugging();
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

// Set up custom content types - associating file extension to MIME type
app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();

app.UseStatusCodePagesWithRedirects("/page-not-found");

app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") =>
{
	var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
		.WithRedirectUri(redirectUri)
		.Build();

	await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") =>
{
	var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
		.WithRedirectUri(redirectUri)
		.Build();

	await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapRazorComponents<App>()
	.AddInteractiveWebAssemblyRenderMode()
	.AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
