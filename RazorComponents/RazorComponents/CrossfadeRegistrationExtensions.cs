using Microsoft.Extensions.DependencyInjection;

namespace CodeChops.Website.RazorComponents;

public static class CrossfadeRegistrationExtensions
{
	public static IServiceCollection AddCrossfade(this IServiceCollection services, bool inServerContext)
	{
		services.AddSingleton<RenderLocation>(inServerContext ? new RenderedOnServer() : new RenderedOnClient());

		return services;
	}
}