using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents.Helpers;

namespace CodeChops.Website.Client;

public static class Branding
{
	public const string Name			= "CodeChops";
	public const string EmailAddress	= "hello@codechops.nl";
	public const string PhoneNumber		= "+31 (0)6 2093 7730";
	public const string GitHubLink		= "https://github.com/Code-Chops";
	public const string LinkedInLink	= "https://www.linkedin.com/in/max-bergman7";

	public const string FontFamily		= "Montserrat";

	public static int FontWeight		=> ColorModeSelector.Value == ColorMode.DarkMode ? 170 : 325;
	public static string TextSpacing	=> ColorModeSelector.Value == ColorMode.DarkMode ? "0.134px" : "normal";

	public static class Colors
	{
		public static FlexColor Main		{ get ; } = new("#730030");
		public static FlexColor Accent		{ get ; } = new("#9f607a");
		public static FlexColor DarkGray	{ get ; } = new("#1e1e1e");

		public static FlexColor Background => ColorModeSelector.Value == ColorMode.DarkMode ? DarkGray : FlexColor.White;
	}

	public static string BannerText { get; } = $"""
	                                            
	                                               ___          _        ___ _
	                                              / __\___   __| | ___  / __| |__   ___  _ __  ___
	                                             / /  / _ \ / _` |/ _ \/ /  | '_ \ / _ \| '_ \/ __|
	                                            / /__| (_) | (_| |  __/ /___| | | | (_) | |_) \__ \
	                                            \____/\___/ \__,_|\___\____/|_| |_|\___/| .__/|___/
	                                                                                    |_|
	                                                                           ©{DateTime.Now.Year} by Max Bergman

	                                            """;
}
