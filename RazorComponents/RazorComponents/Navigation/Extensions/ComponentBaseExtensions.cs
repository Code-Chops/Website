using System;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components;

/// <summary>
/// Provides extensions on <see cref="ComponentBase"/> related to navigation.
/// </summary>
public static class ComponentBaseExtensions
{
	/// <summary>
	/// Returns the current page's URL from its shortest <see cref="RouteAttribute"/>.
	/// Throws if the component has no such attribute.
	/// </summary>
	public static string GetPageUrlFromRoute<TPage>(this TPage page)
		where TPage : ComponentBase
	{
		if (page is null) throw new ArgumentNullException(nameof(page));

		return PageUrlCache<TPage>.PageUrl;
	}

	private static class PageUrlCache<T>
	{
		public static string PageUrl { get; } = (typeof(T).GetCustomAttributes<RouteAttribute>()
			.OrderBy(attribute => attribute.Template.Length)
			.FirstOrDefault() ?? throw new InvalidOperationException($"{typeof(T).Name} does not have a {nameof(RouteAttribute)}.")).Template;
	}
}