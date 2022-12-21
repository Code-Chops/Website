using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents.Helpers;

namespace CodeChops.Website.Client;

public static class Branding
{
	public const string Name			= "CodeChops";
	public const string EmailAddress	= "hello@codechops.nl";
	public const string PhoneNumber		= "+31 (0)6 2093 7730";
	public const string Address			= "Oudenoord 330 Utrecht";
	public const string AddressLink		= "https://goo.gl/maps/RYXDfLQx4sBVmRTN6";
	public const string GitHubLink		= "https://github.com/Code-Chops";
	
	public const string FontFamily		= "Montserrat";
	
	public static int FontWeight		=> 170;
	public static string TextShadow		=> ColorModeSelector.Value == ColorMode.DarkMode ? "-1px" : "1px";
	public static string TextSpacing	=> "normal";

	public static class Colors
	{
		public static readonly FlexColor Main		= new("#730030");
		public static readonly FlexColor Accent		= new("#9f607a");
		public static readonly FlexColor DarkGray	= new("#1e1e1e");
		
		public static FlexColor Background => ColorModeSelector.Value == ColorMode.DarkMode ? DarkGray : FlexColor.White;
	}

	public static readonly string BannerText = $@"
   ___          _        ___ _                     
  / __\___   __| | ___  / __| |__   ___  _ __  ___ 
 / /  / _ \ / _` |/ _ \/ /  | '_ \ / _ \| '_ \/ __|
/ /__| (_) | (_| |  __/ /___| | | | (_) | |_) \__ \
\____/\___/ \__,_|\___\____/|_| |_|\___/| .__/|___/
                                        |_|        
                               ©{DateTime.Now.Year} by Max Bergman
";
}
