using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Layout;

internal record ColorMode : MagicEnum<ColorMode>
{
	public static ColorMode LightMode = CreateMember();
	public static ColorMode DarkMode = CreateMember();
}