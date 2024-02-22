using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace CodeChops.Website.RazorComponents.Navigation.Pages;

/// <summary>
/// References a page in the portal.
/// </summary>
public abstract class PageReference
{
	public Type PageClass { get; }
	public string Route { get; }
	public string Title { get; }
	/// <summary>
	/// The icon class(es), e.g. "oi oi-home".
	/// </summary>
	public string Icon { get; }

	public Assembly Assembly => this.PageClass.Assembly;

	protected PageReference(Type pageClass, string route, string title, string icon)
	{
		this.PageClass = pageClass ?? throw new ArgumentNullException(nameof(pageClass));
		this.Route = route ?? throw new ArgumentNullException(nameof(route));
		this.Title = title ?? throw new ArgumentNullException(nameof(title));
		this.Icon = icon ?? throw new ArgumentNullException(nameof(icon));
	}
}

/// <summary>
/// References a page in the portal, defined by class <typeparamref name="T"/>.
/// </summary>
public class PageReference<T> : PageReference
	where T : ComponentBase
{
	/// <param name="title">The human-readable page title, as shown in the navigation bar.</param>
	/// <param name="icon">The icon to show next to the title, e.g. "oi oi-home".</param>
	public PageReference(string title, string icon)
		: base(typeof(T), GetRouteFromAttribute(), title, icon)
	{
	}

	private static string GetRouteFromAttribute()
	{
		// Use the shortest route if multiple are specified
		var routeAttribute = typeof(T)
			.GetCustomAttributes<RouteAttribute>()
			.MinBy(attribute => attribute.Template.Length);

		if (routeAttribute is null)
			throw new Exception($"{typeof(T)} does not seem to be a concrete Razor page. Is the @page directive missing?");

		var result = routeAttribute.Template;
		return result;
	}
}
