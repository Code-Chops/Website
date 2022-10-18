using System.Reflection;

namespace CodeChops.Website.RazorComponents.Navigation.Pages;

/// <summary>
/// Defines a functional area within the portal.
/// An area usually matches a Bounded Context.
/// </summary>
public class Area
{
	public string Title { get; }
	public IReadOnlyList<PageReference> Pages { get; }
	public Assembly Assembly { get; }

	/// <param name="title">The human-readable title of the area.</param>
	/// <param name="pages">The area's pages exposed through the menu.</param>
	public Area(string title, IReadOnlyList<PageReference> pages)
	{
		this.Pages = pages.ToList() ?? throw new ArgumentNullException(nameof(pages));

		if (this.Pages.Count == 0) throw new ArgumentException("An area must have at least one accessible page.");

		this.Assembly = this.Pages.Select(page => page.Assembly).Distinct().Single();
		this.Title = title ?? throw new ArgumentNullException(nameof(title));
	}
}
