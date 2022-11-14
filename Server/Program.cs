using System.Globalization;
using CodeChops.Website.RazorComponents;
using CodeChops.Website.RazorComponents.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCrossfade(inServerContext: true);

var supportedCountryCodes = new CountryCode[] { new("GB"), new("NL") };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCountryCodes.First());
	options.SupportedUICultures = supportedCountryCodes.Select(country => new CultureInfo(country)).ToList();
});

builder.Services.AddCountryCache(supportedCountryCodes, supportedCountryCodes.First());

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
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
