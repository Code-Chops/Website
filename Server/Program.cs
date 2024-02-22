// #define UseAuthorization

using System.Globalization;
using System.Net;
using CodeChops.Crossblade;
using CodeChops.LightResources;
using CodeChops.Website.Client;
#if UseAuthorization
using Auth0.AspNetCore.Authentication;
using CodeChops.Website.Server.AuthenticationStateSyncer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
#endif

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

#if UseAuthorization
services
	.AddAuth0WebAppAuthentication(options => {
		options.Domain = builder.Configuration["Auth0:Domain"]!;
		options.ClientId = builder.Configuration["Auth0:ClientId"]!;
	});

	services.AddCascadingAuthenticationState();
	services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();
#endif

// Temporary workaround, see: https://github.com/dotnet/aspnetcore/issues/52530
services.Configure<RouteOptions>(options => options.SuppressCheckForUnhandledSecurityMetadata = true);

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

app.UseStatusCodePages(handler =>
{
	switch (handler.HttpContext.Response.StatusCode)
	{
		case (int)HttpStatusCode.NotFound:
			handler.HttpContext.Response.Redirect("/page-not-found");
			break;
		case (int)HttpStatusCode.Unauthorized:
			handler.HttpContext.Response.Redirect("/unauthorized");
			break;
	}

	return Task.CompletedTask;
});

#if UseAuthorization
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
#endif


app.MapRazorComponents<App>()
	.AddInteractiveWebAssemblyRenderMode()
	.AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
