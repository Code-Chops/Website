using System.Globalization;
using CodeChops.Crossblade;
using CodeChops.LightResources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCrossblade(new RenderEnvironment.WebassemblyHost());
builder.Services.AddSingleton<CodeChops.Website.RazorComponents.RenderEnvironment>(new CodeChops.Website.RazorComponents.RenderEnvironment.WebassemblyHost());

builder.Services.AddScoped<HttpClient>();

builder.Services.AddLightResources(new LanguageCode[] { new("en-GB"), new("nl-NL") });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(LanguageCodeCache.CurrentLanguageCode);
	options.SupportedUICultures = SupportedLanguageCodes.GetValues().Select(languageCode => new CultureInfo(languageCode)).ToList();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

// Set up custom content types - associating file extension to MIME type
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
