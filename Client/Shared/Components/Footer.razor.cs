namespace CodeChops.Website.Client.Shared.Components;

public partial class Footer
{
	private static Version? Version { get; } = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
}
