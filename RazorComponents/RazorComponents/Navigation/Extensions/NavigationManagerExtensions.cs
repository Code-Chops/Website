using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Components;

/// <summary>
/// Provides general extensions on <see cref="NavigationManager"/>.
/// </summary>
public static class NavigationManagerExtensions
{
	/// <summary>
	/// <para>
	/// Navigates to the given <typeparamref name="TPage"/>, with an optional subroute, and the option to retain the current query string.
	/// The fragment (#subsection) is not retained.
	/// </para>
	/// <para>
	/// <strong>Does</strong> trigger OnParametersSet[Async], provided that the route changes.
	/// </para>
	/// </summary>
	/// <typeparam name="TPage">The page to navigate to. This method uses the page's shortest "@page" directive, or throws if it has none.</typeparam>
	/// <param name="retainQueryString">Whether to retain the current query string.</param>
	/// <param name="subroute">The subroute within the current page. Null or empty simply navigates to the current page's primary URL. The leading '/' character is optional.</param>
	public static void NavigateToPage<TPage>(this NavigationManager navigationManager, bool retainQueryString, string? subroute = null)
		where TPage : ComponentBase
	{
		NavigateToPage(navigationManager, retainQueryString, typeof(TPage), subroute);
	}

	/// <summary>
	/// <para>
	/// Navigates to the given page, with an optional subroute, and the option to retain the current query string.
	/// The fragment (#subsection) is not retained.
	/// </para>
	/// <para>
	/// <strong>Does</strong> trigger OnParametersSet[Async], provided that the route changes.
	/// </para>
	/// </summary>
	/// <param name="retainQueryString">Whether to retain the current query string.</param>
	/// <param name="page">The page to navigate to. This method uses the page's shortest "@page" directive, or throws if it has none.</param>
	/// <param name="subroute">The subroute within the current page. Null or empty simply navigates to the current page's primary URL. The leading '/' character is optional.</param>
	public static void NavigateToPage(this NavigationManager navigationManager, bool retainQueryString, Type page, string? subroute = null)
	{
		if (navigationManager is null) throw new ArgumentNullException(nameof(navigationManager));
		if (page is null) throw new ArgumentNullException(nameof(page));

		var pageUrl = page.GetCustomAttributes<RouteAttribute>()
			.OrderBy(attribute => attribute.Template.Length)
			.FirstOrDefault()?.Template;

		if (pageUrl is null)
			throw new ArgumentException($"Page {page.Name} has no @page directive or route attribute.");

		// Make null work
		subroute ??= "";

		// Avoid double slashes
		if (subroute.StartsWith('/') && pageUrl.EndsWith('/'))
			pageUrl = pageUrl.TrimStart('/');

		var pathSeparator = subroute.Length == 0 || subroute[0] == '/' || pageUrl.EndsWith('/')
			? "" // No subroute, or we already have a separator character
			: "/";

		var queryString = retainQueryString ? navigationManager.ToAbsoluteUri(navigationManager.Uri).Query : "";

		var targetUrl = $"{pageUrl}{pathSeparator}{subroute}{queryString}";
		navigationManager.NavigateTo(targetUrl);
	}

	/// <summary>
	/// <para>
	/// Updates the current URL, replacing the query string by the given one.
	/// </para>
	/// <para>
	/// Does <strong>not</strong> actually <em>navigate</em> or trigger OnParametersSet[Async].
	/// </para>
	/// </summary>
	/// <param name="queryString">The query string to set. Null or empty unsets the query string. The leading '?' character is optional. Escaping is up to the caller.</param>
	/// <param name="retainFragment">If true, if a fragment (#subsection) is present, it is kept. Otherwise, it is discarded.</param>
	public static void ReplaceQueryString(this NavigationManager navigationManager, string? queryString, bool retainFragment = true)
	{
		// Make null work
		queryString ??= "";

		var queryStringSeparator = queryString.Length == 0 || queryString[0] == '?'
			? "" // No query string, or we already have a separator character
			: "?";

		var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);

		var fragment = retainFragment ? uri.Fragment : "";
		var uriWithoutQueryString = uri.AbsolutePath;

		var targetUrl = $"{uriWithoutQueryString}{queryStringSeparator}{queryString}{fragment}";
		navigationManager.NavigateTo(targetUrl);
	}

	/// <summary>
	/// <para>
	/// Updates the current URL, replacing the query string by one created from the given <paramref name="queryParameters"/>.
	/// </para>
	/// <para>
	/// Does <strong>not</strong> actually <em>navigate</em> or trigger OnParametersSet[Async].
	/// </para>
	/// </summary>
	/// <param name="queryParameters">The query parameters used to build the new query string. Parameters with null values are removed.</param>
	/// <param name="retainFragment">If true, if a fragment (#subsection) is present, it is kept. Otherwise, it is discarded.</param>
	public static void ReplaceQueryString(this NavigationManager navigationManager, IReadOnlyDictionary<string, string> queryParameters, bool retainFragment = true)
	{
		if (queryParameters is null) throw new ArgumentNullException(nameof(queryParameters));

		var queryStringBuilder = new StringBuilder();

		var i = 0;
		foreach (var pair in queryParameters.Where(pair => pair.Value is not null))
		{
			queryStringBuilder.Append(++i > 1 ? '&' : '?');
			queryStringBuilder.Append(UrlEncoder.Default.Encode(pair.Key));

			if (pair.Value != "")
			{
				queryStringBuilder.Append('=');
				queryStringBuilder.Append(UrlEncoder.Default.Encode(pair.Value));
			}
		}

		var queryString = queryStringBuilder.ToString();
		navigationManager.ReplaceQueryString(queryString, retainFragment);
	}

	/// <summary>
	/// <para>
	/// Updates the current URL, editing the query string by adding or overwriting parameters passed in <paramref name="queryParameters"/>.
	/// </para>
	/// <para>
	/// Existing query parameters are retained. Those also included in <paramref name="queryParameters"/> are overwritten.
	/// </para>
	/// <para>
	/// Does <strong>not</strong> actually <em>navigate</em> or trigger OnParametersSet[Async].
	/// </para>
	/// </summary>
	/// <param name="queryParameters">The query parameters used to build the new query string. Parameters with null values are removed.</param>
	/// <param name="retainFragment">If true, if a fragment (#subsection) is present, it is kept. Otherwise, it is discarded.</param>
	public static void UpdateQueryString(this NavigationManager navigationManager, IReadOnlyDictionary<string, string> queryParameters, bool retainFragment = true)
	{
		if (queryParameters is null) throw new ArgumentNullException(nameof(queryParameters));

		var mergedParameters = navigationManager.GetQueryParameters();

		foreach (var pair in queryParameters)
			mergedParameters[pair.Key] = pair.Value;

		navigationManager.ReplaceQueryString(mergedParameters, retainFragment);
	}

	/// <summary>
	/// <para>
	/// Takes the query string of the current URL and decomposes it into a set of key-value pairs.
	/// </para>
	/// <para>
	/// If a query parameter occurs multiple times, the last occurrence wins.
	/// </para>
	/// </summary>
	public static Dictionary<string, string> GetQueryParameters(this NavigationManager navigationManager)
	{
		var result = new Dictionary<string, string>();

		var queryString = navigationManager.ToAbsoluteUri(navigationManager.Uri).Query.AsSpan();

		// Trim any number of leading '?', since that seems to be the best interpretation of intent (plus it is unclear whether the leading '?' is included or not)
		queryString = queryString.TrimStart('?');

		while (!queryString.IsEmpty)
		{
			queryString = queryString.TrimStart('&');

			var paramSeparatorIndex = queryString.IndexOf('&');
			if (paramSeparatorIndex < 0) paramSeparatorIndex = queryString.Length;

			var key = queryString[..paramSeparatorIndex];
			queryString = queryString[paramSeparatorIndex..];

			// Skip empty entries
			if (key.IsEmpty) continue;

			// Start with everything as the key and an empty value
			var value = ReadOnlySpan<char>.Empty;

			// If there is '=', split into key and value
			var valueSeparatorIndex = key.IndexOf('=');
			if (valueSeparatorIndex >= 0) // Allow the empty string as key
			{
				value = key[(1 + valueSeparatorIndex)..];
				key = key[..valueSeparatorIndex];
			}

			var unescapedKey = Uri.UnescapeDataString(key.ToString());
			var unescapedValue = Uri.UnescapeDataString(value.ToString());
			result[unescapedKey] = unescapedValue;
		}

		return result;
	}
}