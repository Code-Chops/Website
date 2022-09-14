using ColorHelper;

namespace CodeChops.Website.RazorComponents.Helpers;

public readonly record struct Color
{
	/// <summary>
	/// HEX representation.
	/// </summary>
	public override string ToString() => this.Hex;

	public static Color White { get; } = new(255, 255, 255);

	public string Hex { get; }
	
	/// <summary>
	/// Format: "{r}, {g}, {b}"
	/// </summary>
	public string Rgb { get; }

	private RGB Value { get; }

	public Color(byte r, byte g, byte b)
		: this(new RGB(r, g, b))
	{
	}

	public Color(RGB rgbColor)
		: this(ColorConverter.RgbToHex(rgbColor), rgbColor)
	{
	}

	public Color(string hexColor)
		: this(new HEX(hexColor))
	{
	}

	public Color(HEX hexColor) 
		: this(hexColor, ColorConverter.HexToRgb(hexColor))
	{
	}

	public Color(ColorName colorName)
		: this(colorName.ToHex(), colorName.ToRgb())
	{
	}

	private Color(HEX hexColor, RGB rgbColor)
	{
		this.Hex = $"#{hexColor}";
		this.Rgb = $"{rgbColor.R}, {rgbColor.G}, {rgbColor.B}";
		this.Value = rgbColor;
	}

	public readonly Color ChangeBrightness(int delta = 40)
	{
		var r = ChangeBrightnessOfPrimaryColor(this.Value.R);
		var g = ChangeBrightnessOfPrimaryColor(this.Value.G);
		var b = ChangeBrightnessOfPrimaryColor(this.Value.B);
		var color = new Color(r, g, b);

		return color;


		byte ChangeBrightnessOfPrimaryColor(byte primaryColor)
		{
			var newColor = primaryColor + delta;
			if (newColor > 255) return 255;
			if (newColor < 0) return 0;

			return (byte)newColor;
		}
	}
}