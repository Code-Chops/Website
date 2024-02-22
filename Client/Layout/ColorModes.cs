using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Layout;

internal sealed record ColorMode : MagicEnum<ColorMode>
{
	public static ColorMode LightMode	{ get; } = CreateMember();
	public static ColorMode DarkMode	{ get; } = CreateMember();
}
