using CodeChops.Website.Client.Layout;
using CodeChops.Website.RazorComponents.Helpers;

namespace CodeChops.Website.Client;

public static class Branding
{
	public const string Name = "CodeChops";
	public const string FontFamily = "Kaufmann";

	public static class Colors
	{
		public static readonly Color Main = new("#730030");
		public static readonly Color Accent = new("#8c3459");
		public static readonly Color DarkGray = new("#1e1e1e");
		public static Color Background => ColorModeSelector.ColorMode is DarkMode ? DarkGray : Color.White;
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

// Mosque: #9DB6BD
// Grijsblauw: #8699A7
// Blauw: #79a5c5
// Frisblauw: #b0d1e9
// Dark background: #1D1D1D #13161a