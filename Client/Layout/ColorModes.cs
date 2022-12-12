using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Layout;

internal record ColorMode : MagicEnum<ColorMode>
{
	public static readonly ColorMode LightMode	= CreateMember();
	public static readonly ColorMode DarkMode	= CreateMember();
}
