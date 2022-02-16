namespace CodeChops.Website.Client.Layout;

internal abstract record ColorMode;
internal record LightMode : ColorMode
{
	public static readonly LightMode Instance = new();
	private LightMode() { }
}
internal record DarkMode : ColorMode
{
	public static readonly DarkMode Instance = new();
	private DarkMode() { }
}